using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JustMovedGit.Classes;

namespace JustMovedGit.Adapters
{
    class VeiligheidAdapter : BaseAdapter<Veiligheid>
    {
        private List<Veiligheid> veiligheid;
        private Context mContext;
        private int mtestLayout;

        public VeiligheidAdapter(Context context, List<Veiligheid> items, int testLayout)
        {
            veiligheid = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return veiligheid.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Veiligheid this[int position]
        {
            get { return veiligheid[position]; }
        }

        public Veiligheid GetVeiligheid(int position)
        {
            return veiligheid[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            TextView txtTitel = row.FindViewById<TextView>(Resource.Id.txtTitel);
            txtTitel.Text = veiligheid[position].ongeval;

            return row;
        }
    }
}