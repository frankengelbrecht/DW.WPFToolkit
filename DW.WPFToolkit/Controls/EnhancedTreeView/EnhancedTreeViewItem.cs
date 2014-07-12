﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.TreeViewItem" /> to be able to let is stretch over the whole width of the parent control.
    /// </summary>
    public class EnhancedTreeViewItem : TreeViewItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem" /> class.
        /// </summary>
        public EnhancedTreeViewItem()
        {
            var binding = new Binding("ItemsContentStretching");
            binding.RelativeSource = new RelativeSource();
            binding.RelativeSource.Mode = RelativeSourceMode.FindAncestor;
            binding.RelativeSource.AncestorType = typeof(EnhancedTreeView);
            SetBinding(ContentStretchingProperty, binding);
        }

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new EnhancedTreeViewItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnhancedTreeViewItem;
        }

        /// <summary>
        /// Gets or sets a value which is indicating if the current item should be stretched over the whole width of the tree view or not.
        /// </summary>
        public bool ContentStretching
        {
            get { return (bool)GetValue(ContentStretchingProperty); }
            set { SetValue(ContentStretchingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedTreeViewItem.ContentStretching" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentStretchingProperty =
            DependencyProperty.Register("ContentStretching", typeof(bool), typeof(EnhancedTreeViewItem), new UIPropertyMetadata(OnContentStretchingChanged));

        private static void OnContentStretchingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var value = (bool)e.NewValue;
            if (value)
            {
                var control = (EnhancedTreeViewItem)sender;
                if (control.IsLoaded)
                    control.AdjustChildren();
                else
                    control.Loaded += new RoutedEventHandler(control.StretchingTreeViewItem_Loaded);
            }
        }

        private void StretchingTreeViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustChildren();
        }

        private void AdjustChildren()
        {
            if (VisualChildrenCount > 0)
            {
                var grid = GetVisualChild(0) as Grid;
                if (grid != null &&
                    grid.ColumnDefinitions.Count == 3)
                    grid.ColumnDefinitions.RemoveAt(1);
            }
        }
    }
}
