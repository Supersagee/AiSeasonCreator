using System;
using System.Collections.Generic;
using System.ComponentModel;

public class SortableBindingList<T> : BindingList<T>
{
    private bool _isSorted;
    private ListSortDirection _sortDirection;
    private PropertyDescriptor _sortProperty;

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => _isSorted;
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;
    protected override ListSortDirection SortDirectionCore => _sortDirection;

    protected override void ApplySortCore(
        PropertyDescriptor prop,
        ListSortDirection direction)
    {
        _sortProperty = prop;
        _sortDirection = direction;

        var list = (List<T>)Items;
        list.Sort((x, y) =>
        {
            var a = prop.GetValue(x) as IComparable;
            var b = prop.GetValue(y) as IComparable;
            if (a == null) return b == null ? 0 : -1;
            return direction == ListSortDirection.Ascending
                ? a.CompareTo(b)
                : b.CompareTo(a);
        });

        _isSorted = true;
        OnListChanged(new ListChangedEventArgs(
            ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore()
    {
        _isSorted = false;
        OnListChanged(new ListChangedEventArgs(
            ListChangedType.Reset, -1));
    }
}
