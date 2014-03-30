using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardMaker.ClassStuff;

namespace CardMaker
{
    public partial class FeatureCtrl<T> : UserControl, IReturnsData<T>
    {
        Type type;
        T thing;
        public FeatureCtrl(T feature)
        {
            InitializeComponent();
            thing = feature;
            type = typeof(T);
            LoadData();
        }

        public void LoadData()
        {
            if (type == typeof(BasicPower))
            {
                BasicPower power = thing as BasicPower;
                nameText.Text = power.PowerName;
                descText.Text = power.Description;
            }
            else if (type == typeof(Feature))
            {
                Feature feature = thing as Feature;
                nameText.Text = feature.Name;
                descText.Text = feature.Description;
            }
            else if (type == typeof(BasicItem))
            {
                BasicItem item = thing as BasicItem;
                nameText.Text = item.Name;
                descText.Text = item.Description;
            }
            else throw new InvalidCastException("FeatureCtrl does not support the given class");
        }

        public T GetData()
        {
            if (typeof(T) == type)
            {
                if (type == typeof(BasicPower))
                {
                    (thing as BasicPower).Description = descText.Text;
                    (thing as BasicPower).PowerName = nameText.Text;
                    return thing;
                }
                else if (type == typeof(Feature))
                {
                    (thing as Feature).Description = descText.Text;
                    (thing as Feature).Name = nameText.Text;
                    return thing;
                }
                else if (type == typeof(BasicItem))
                {
                    (thing as BasicItem).Description = descText.Text;
                    (thing as BasicItem).Name = nameText.Text;
                    return thing;
                }
                else throw new InvalidCastException();
            }
            else throw new InvalidCastException();
        }
    }
}
