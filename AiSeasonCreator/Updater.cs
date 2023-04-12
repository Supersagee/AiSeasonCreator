using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace AiSeasonCreator
{
    public class Updater
    {
        public Updater() { }

        public async void CheckForUpdates()
        {
            JObject latestReleaseInfo;
            try
            {
                latestReleaseInfo = await GetLatestReleaseInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}");
                return;
            }

            if (IsUpdateAvailable(latestReleaseInfo))
            {
                using (var updateForm = new UpdateForm(latestReleaseInfo))
                {
                    var result = updateForm.ShowDialog();

                    if (result == DialogResult.Yes)
                    {
                        await DownloadAndRunInstaller(latestReleaseInfo);
                        Application.Exit();
                    }
                }
            }
        }

        private async Task<JObject> GetLatestReleaseInfo()
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AiSeasonCreator");

            var response = await httpClient.GetAsync("https://api.github.com/repos/Supersagee/AiSeasonCreator/releases/latest");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody);
        }

        private bool IsUpdateAvailable(JObject latestReleaseInfo)
        {
            string tagName = latestReleaseInfo["tag_name"].ToString();
            string versionString = tagName.StartsWith("v") ? tagName.Substring(1) : tagName;
            var latestVersion = new Version(versionString);

            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

            return latestVersion > currentVersion;
        }

        public async Task DownloadAndRunInstaller(JObject latestReleaseInfo)
        {
            using var httpClient = new HttpClient();
            var assets = latestReleaseInfo["assets"] as JArray;
            var installerAsset = assets.FirstOrDefault(asset => asset["name"].ToString().EndsWith(".exe"));

            if (installerAsset == null)
            {
                MessageBox.Show("No installer found in the latest release.");
                return;
            }

            var installerUrl = installerAsset["browser_download_url"].ToString();
            var installerPath = Path.Combine(Path.GetTempPath(), installerAsset["name"].ToString());

            using (var response = await httpClient.GetAsync(installerUrl))
            {
                response.EnsureSuccessStatusCode();
                using (var fileStream = File.Create(installerPath))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }

            Process.Start(installerPath);
        }
    }
}
