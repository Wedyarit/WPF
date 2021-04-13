using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._03._2021
{

    public class PagingCollectionView : System.Windows.Data.CollectionView
    {
        private readonly IList _innerList;
        private readonly int _itemsPerPage;

        private int _currentPage = 1;

        public PagingCollectionView(IList innerList, int itemsPerPage)
            : base(innerList)
        {
            this._innerList = innerList;
            this._itemsPerPage = itemsPerPage;
        }

        public override int Count
        {
            get
            {
                if (this._innerList.Count == 0) return 0;
                if (this._currentPage < this.PageCount)
                    return this._itemsPerPage;
                else
                {
                    var itemsLeft = this._innerList.Count % this._itemsPerPage;
                    if (0 == itemsLeft)
                        return this._itemsPerPage;
                    else
                        return itemsLeft;
                }
            }
        }

        public int CurrentPage
        {
            get { return this._currentPage; }
            set
            {
                this._currentPage = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public int ItemsPerPage { get { return this._itemsPerPage; } }

        public int PageCount { get { return (this._innerList.Count + this._itemsPerPage - 1) / this._itemsPerPage; } }

        private int StartIndex
        {
            get { return (this._currentPage - 1) * this._itemsPerPage; }
        }

        public override object GetItemAt(int index)
        {
            var offset = index % (this._itemsPerPage);
            return this._innerList[this.StartIndex + offset];
        }

        public void MoveToNextPage()
        {
            if (this._currentPage < this.PageCount)
                this.CurrentPage += 1;
            this.Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (this._currentPage > 1)
                this.CurrentPage -= 1;
            this.Refresh();
        }
    }
}
