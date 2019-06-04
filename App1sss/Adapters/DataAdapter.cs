using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using App1sss;
using UGAndroidCloud.Models;

namespace UGAndroidCloud.Adapters
{
    class DataAdapter : RecyclerView.Adapter
    {
        public event EventHandler<DataAdapterClickEventArgs> ItemClick;
        public event EventHandler<DataAdapterClickEventArgs> ItemLongClick;
        List<InfoModel> infosList;

        public DataAdapter(List<InfoModel> data)
        {
            infosList = data;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = null;

            itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);
            var vh = new DataAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = infosList[position];

            if (item != null && viewHolder != null)
            {
                var holder = viewHolder as DataAdapterViewHolder;
                holder.TypeText.Text = !string.IsNullOrWhiteSpace(item.Type) ? item.Type : "";
                holder.BreedText.Text = !string.IsNullOrWhiteSpace(item.Breed) ? item.Breed : "";
                holder.NameText.Text = !string.IsNullOrWhiteSpace(item.Name) ? item.Name : "";
                holder.InfoText.Text = !string.IsNullOrWhiteSpace(item.Info) ? item.Info : "";
            }
        }

        public override int ItemCount => infosList.Count;

        void OnClick(DataAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(DataAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class DataAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TypeText { get; set; }
        public TextView BreedText { get; set; }
        public TextView NameText { get; set; }
        public TextView InfoText { get; set; }


        public DataAdapterViewHolder(View itemView, Action<DataAdapterClickEventArgs> clickListener,
                            Action<DataAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            TypeText = (TextView)ItemView.FindViewById(Resource.Id.Type);
            BreedText = (TextView)ItemView.FindViewById(Resource.Id.Breed);
            NameText = (TextView)ItemView.FindViewById(Resource.Id.Name);
            InfoText = (TextView)ItemView.FindViewById(Resource.Id.Info);

            itemView.Click += (sender, e) => clickListener(new DataAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new DataAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class DataAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}