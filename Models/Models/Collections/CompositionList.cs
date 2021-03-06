﻿using NMF.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NMF.Models.Collections
{
    public class CompositionList<T> : Collection<T> where T : class, IModelElement
    {
        public IModelElement Parent { get; private set; }
        private bool silent;

        public CompositionList(IModelElement parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");

            Parent = parent;
        }

        protected override void ClearItems()
        {
            if (!silent)
            {
                silent = true;
                foreach (var item in this)
                {
                    if (item != null)
                    {
                        item.Deleted -= RemoveItem;
                        if (item.Parent == Parent)
                        {
                            item.Parent = null;
                            item.Delete();
                        }
                    }
                }
                base.ClearItems();
                silent = false;
            }
        }

        protected override void InsertItem(int index, T item)
        {
            if (!silent && item != null)
            {
                item.Deleted += RemoveItem;
                silent = true;
                item.Parent = Parent;
                base.InsertItem(index, item);
                silent = false;
            }
        }

        protected override void RemoveItem(int index)
        {
            if (!silent)
            {
                silent = true;
                var item = this[index];
                base.RemoveItem(index);
                if (item != null)
                {
                    item.Deleted -= RemoveItem;
                    if (item.Parent == Parent)
                    {
                        item.Parent = null;
                        item.Delete();
                    }
                }
                silent = false;
            }
        }

        protected override void SetItem(int index, T item)
        {
            if (!silent)
            {
                silent = true;
                var oldItem = this[index];
                if (oldItem != item)
                {
                    if (item != null)
                    {
                        item.Deleted += RemoveItem;
                    }
                    if (oldItem != null)
                    {
                        oldItem.Deleted -= RemoveItem;
                    }
                    base.SetItem(index, item);
                    if (oldItem != null && oldItem.Parent == Parent)
                    {
                        oldItem.Parent = null;
                        oldItem.Delete();
                    }
                    if (item != null)
                    {
                        item.Parent = Parent;
                    }
                }
                silent = false;
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            var item = sender as T;
            Remove(item);
        }
    }

    public class ObservableCompositionList<T> : ObservableList<T> where T : class, IModelElement
    {
        public IModelElement Parent { get; private set; }
        private bool silent;

        public ObservableCompositionList(IModelElement parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");

            Parent = parent;
        }

        protected override void ClearItems()
        {
            if (!silent)
            {
                silent = true;
                foreach (var item in this)
                {
                    if (item != null)
                    {
                        item.Deleted -= RemoveItem;
                        if (item.Parent == Parent)
                        {
                            item.Parent = null;
                            item.Delete();
                        }
                    }
                }
                base.ClearItems();
                silent = false;
            }
        }

        protected override void InsertItem(int index, T item)
        {
            if (!silent && item != null)
            {
                silent = true;
                item.Deleted += RemoveItem;
                item.Parent = Parent;
                base.InsertItem(index, item);
                silent = false;
            }
        }

        protected override void RemoveItem(int index)
        {
            if (!silent)
            {
                silent = true;
                var item = this[index];
                base.RemoveItem(index);
                if (item != null)
                {
                    item.Deleted -= RemoveItem;
                    if (item.Parent == Parent)
                    {
                        item.Parent = null;
                        item.Delete();
                    }
                }
                silent = false;
            }
        }

        protected override void SetItem(int index, T item)
        {
            if (!silent)
            {
                silent = true;
                var oldItem = this[index];
                if (oldItem != item)
                {
                    if (item != null)
                    {
                        item.Deleted += RemoveItem;
                    }
                    if (oldItem != null)
                    {
                        oldItem.Deleted -= RemoveItem;
                    }
                    base.SetItem(index, item);

                    if (oldItem != null && oldItem.Parent == Parent)
                    {
                        oldItem.Parent = null;
                        oldItem.Delete();
                    }
                    if (item != null)
                    {
                        item.Parent = Parent;
                    }
                }
                silent = false;
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            var item = sender as T;
            Remove(item);
        }
    }
}
