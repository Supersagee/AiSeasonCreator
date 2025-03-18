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
            var updater = new AiSeasonCreator.Updater();

            try
            {
                latestReleaseInfo = await updater.GetLatestReleaseInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}");
                return;
            }

            if (updater.IsUpdateAvailable(latestReleaseInfo))
            {
                using (var updateForm = new UpdateForm(latestReleaseInfo))
                {
                    var result = updateForm.ShowDialog();

                    if (result == DialogResult.Yes)
                    {
                        string installerUrl = updater.FindInstallerAsset(latestReleaseInfo);
                        if (installerUrl == null)
                        {
                            MessageBox.Show("No installer found in the latest release.");
                            return;
                        }

                        await updater.DownloadAndRunInstaller(installerUrl);
                        Application.Exit();
                    }
                }
            }
        }

        public string FindInstallerAsset(JObject latestReleaseInfo)
        {
            var assets = latestReleaseInfo["assets"] as JArray;

            StringBuilder assetNames = new StringBuilder("Assets in the latest release:\n");
            foreach (var asset in assets)
            {
                string assetName = asset["name"].ToString();
                assetNames.AppendLine($"- {assetName}");

                if (assetName.Equals("AiSeasonCreatorSetup.msi", StringComparison.OrdinalIgnoreCase))
                {
                    return asset["browser_download_url"].ToString();
                }
            }

            MessageBox.Show(assetNames.ToString());
            return null;
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

        public async Task DownloadAndRunInstaller(string installerUrl)
        {
            using var httpClient = new HttpClient();

            string installerFileName = Path.GetFileName(installerUrl);

            var installerPath = Path.Combine(Path.GetTempPath(), installerFileName);

            using (var response = await httpClient.GetAsync(installerUrl))
            {
                response.EnsureSuccessStatusCode();
                using (var fileStream = File.Create(installerPath))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }

            Process.Start("msiexec.exe", $"/i \"{installerPath}\"");
        }
    }
}
