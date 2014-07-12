﻿using System.Windows;
using System.Windows.Controls;
using DW.WPFToolkit.Interactivity;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.GridViewColumn" /> by sort information and name.
    /// </summary>
    public class EnhancedGridViewColumn : GridViewColumn
    {
        /// <summary>
        /// Gets or sets the name of the current column. This will be used by the <see cref="DW.WPFToolkit.Controls.EnhancedListView.VisibleColumns" /> collection.
        /// </summary>
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedGridViewColumn.Name" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnNameChanged));

        private static void OnNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnVisibilityBehavior.SetName(sender, (string)e.NewValue);
        }

        /// <summary>
        /// Gets or sets a value which indicates if the current column is the default sort when the <see cref="DW.WPFToolkit.Controls.EnhancedListView" /> is loaded.
        /// </summary>
        public bool IsDefaultSortColumn
        {
            get { return (bool)GetValue(IsDefaultSortColumnProperty); }
            set { SetValue(IsDefaultSortColumnProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedGridViewColumn.IsDefaultSortColumn" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsDefaultSortColumnProperty =
            DependencyProperty.Register("IsDefaultSortColumn", typeof(bool), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnIsDefaultSortColumnChanged));

        private static void OnIsDefaultSortColumnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetIsDefaultSortColumn(sender, (bool)e.NewValue);
        }

        /// <summary>
        /// Gets or sets the property name which will be used for sorting by the current column.
        /// </summary>
        public string SortPropertyName
        {
            get { return (string)GetValue(SortPropertyNameProperty); }
            set { SetValue(SortPropertyNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedGridViewColumn.SortPropertyName" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.Register("SortPropertyName", typeof(string), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnSortPropertyNameChanged));

        private static void OnSortPropertyNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnSortBehavior.SetSortPropertyName(sender, (string)e.NewValue);
        }

        /// <summary>
        /// Gets or sets the proportional width in percent to be used for this column if <see cref="DW.WPFToolkit.Controls.EnhancedListView.AutoSize" /> is set to <see cref="DW.WPFToolkit.Interactivity.ColumnResizeKind.Proportional" />. If the width is set this property has no effect.
        /// </summary>
        public double ProportionalWidth
        {
            get { return (double)GetValue(ProportionalWidthProperty); }
            set { SetValue(ProportionalWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedGridViewColumn.ProportionalWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ProportionalWidthProperty =
            DependencyProperty.Register("ProportionalWidth", typeof(double), typeof(EnhancedGridViewColumn), new UIPropertyMetadata(OnProportionalWidthChanged));

        private static void OnProportionalWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColumnWidthBehavior.SetProportionalWidth(sender, (double)e.NewValue);
        }
    }
}
