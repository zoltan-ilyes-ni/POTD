using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanYourDay.UI.Helpers
{
    // This is a cool idea from stackoverflow, unfortunatelly it requires Blender SDK what I don't have installed and I'm lazy to do so
    // https://stackoverflow.com/questions/1000040/data-binding-to-selecteditem-in-a-wpf-treeview
    // rolling back to old-school TreeView_OnSelectedItemChanged method for now

    //public class BindableSelectedItemBehavior : Behavior<TreeView>
    //{
    //    #region SelectedItem Property

    //    public object SelectedItem
    //    {
    //        get { return (object)GetValue(SelectedItemProperty); }
    //        set { SetValue(SelectedItemProperty, value); }
    //    }

    //    public static readonly DependencyProperty SelectedItemProperty =
    //        DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

    //    private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //    {
    //        var item = e.NewValue as TreeViewItem;
    //        if (item != null)
    //        {
    //            item.SetValue(TreeViewItem.IsSelectedProperty, true);
    //        }
    //    }

    //    #endregion

    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();

    //        this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
    //    }

    //    protected override void OnDetaching()
    //    {
    //        base.OnDetaching();

    //        if (this.AssociatedObject != null)
    //        {
    //            this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
    //        }
    //    }

    //    private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    //    {
    //        this.SelectedItem = e.NewValue;
    //    }
    //}
}
