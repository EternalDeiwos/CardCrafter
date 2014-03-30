using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMaker
{
    public partial class MonsterCtrl : UserControl
    {
        Monster monster;
        public MonsterCtrl(Monster m)
        {
            InitializeComponent();
            monster = m;
            LoadData();
        }

        public void LoadData()
        {
            //Main
            nameText.Text = monster.Name;
            levelText.Text = monster.Level.ToString();
            raceText.Text = monster.Roll;
            sizeText.Text = monster.Size;
            originText.Text = monster.Origin;
            typeText.Text = monster.Type;
            xpText.Text = monster.XPValue.ToString();

            //Body
            initText.Text = monster.Initiative.ToString();
            sensesText.Text = monster.Senses;
            hpText.Text = monster.HP.ToString();
            bloodiedText.Text = monster.Bloodied.ToString();
            acText.Text = monster.AC.ToString();
            fortText.Text = monster.Fort.ToString();
            refText.Text = monster.Ref.ToString();
            willText.Text = monster.Will.ToString();
            savesText.Text = monster.SavesMod;
            resistsText.Text = monster.Resists;
            speedText.Text = monster.Speed.ToString();
            actionPointsText.Text = monster.ActionPoints;
            alignmentText.Text = monster.Alignment;
            languageText.Text = monster.Languages;
            skillsText.Text = monster.Skills;
            equipmentText.Text = monster.Equipment;

            //Scores
            strScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Strength].ToString();
            conScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Constitution].ToString();
            dexScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Dexterity].ToString();
            intScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Intelligence].ToString();
            wisScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Wisdom].ToString();
            chaScoreText.Text = monster.AttributesDict[ClassStuff.Attributes.Charisma].ToString();
            strModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Strength]).ToString();
            conModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Constitution]).ToString();
            dexModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Dexterity]).ToString();
            intModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Intelligence]).ToString();
            wisModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Wisdom]).ToString();
            chaModText.Text = Monster.GetMod(monster.AttributesDict[ClassStuff.Attributes.Charisma]).ToString();

            //Powers
            powerTabCtrl.TabPages.Clear();
            foreach (MinionPower f in monster.Attacks)
            {
                TabPage p = new TabPage();
                p.Text = f.Name;
                MinionPowerCtrl ctrl = new MinionPowerCtrl(f);
                p.Controls.Add(ctrl);
                powerTabCtrl.TabPages.Add(p);
            }

            //Auras
            auraTabCtrl.TabPages.Clear();
            foreach (Aura f in monster.Auras)
            {
                TabPage p = new TabPage();
                p.Text = f.Name;
                AuraCtrl ctrl = new AuraCtrl(f);
                p.Controls.Add(ctrl);
                auraTabCtrl.TabPages.Add(p);
            }
        }

        private void updateChaScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(chaScoreText.Text);
            chaModText.Text = ((score - 10) / 2).ToString();
        }

        private void updateWisScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(wisScoreText.Text);
            wisModText.Text = ((score - 10) / 2).ToString();
        }

        private void updateIntScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(intScoreText.Text);
            intModText.Text = ((score - 10) / 2).ToString();
        }

        private void updateDexScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(dexScoreText.Text);
            dexModText.Text = ((score - 10) / 2).ToString();
        }

        private void updateConScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(conScoreText.Text);
            conModText.Text = ((score - 10) / 2).ToString();
        }

        private void updateStrScore(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(strScoreText.Text);
            strModText.Text = ((score - 10) / 2).ToString();
        }

        public Monster GetData()
        {
            return monster;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            monster.Name = nameText.Text;
            monster.Level = Convert.ToInt32(levelText.Text);
            monster.Roll = raceText.Text;
            monster.Size = sizeText.Text;
            monster.Origin = originText.Text;
            monster.Type = typeText.Text;
            monster.XPValue = Convert.ToInt32(xpText.Text);

            monster.Initiative = Convert.ToInt32(initText.Text);
            monster.Senses = sensesText.Text;
            monster.HP = Convert.ToInt32(hpText.Text);
            if (bloodiedText.Text.Equals("NA")) monster.Bloodied = 0;
            else monster.Bloodied = Convert.ToInt32(bloodiedText.Text);
            monster.AC = Convert.ToInt32(acText.Text);
            monster.Fort = Convert.ToInt32(fortText.Text);
            monster.Ref = Convert.ToInt32(refText.Text);
            monster.Will = Convert.ToInt32(willText.Text);
            monster.SavesMod = savesText.Text;
            monster.Resists = resistsText.Text;
            monster.Speed = Convert.ToInt32(speedText.Text);
            monster.ActionPoints = actionPointsText.Text;

            monster.Alignment = alignmentText.Text;
            monster.Languages = languageText.Text;
            monster.Skills = skillsText.Text;
            monster.Equipment = equipmentText.Text;

            monster.AttributesDict[ClassStuff.Attributes.Strength] = Convert.ToInt32(strScoreText.Text);
            monster.AttributesDict[ClassStuff.Attributes.Constitution] = Convert.ToInt32(conScoreText.Text);
            monster.AttributesDict[ClassStuff.Attributes.Dexterity] = Convert.ToInt32(dexScoreText.Text);
            monster.AttributesDict[ClassStuff.Attributes.Intelligence] = Convert.ToInt32(intScoreText.Text);
            monster.AttributesDict[ClassStuff.Attributes.Wisdom] = Convert.ToInt32(wisScoreText.Text);
            monster.AttributesDict[ClassStuff.Attributes.Charisma] = Convert.ToInt32(chaScoreText.Text);

            monster.Attacks.Clear();
            foreach (TabPage p in powerTabCtrl.TabPages)
            {
                MinionPowerCtrl ctrl = p.Controls[0] as MinionPowerCtrl;
                MinionPower power = ctrl.GetData();
                monster.Attacks.Add(power);
            }

            monster.Auras.Clear();
            foreach (TabPage p in auraTabCtrl.TabPages)
            {
                AuraCtrl ctrl = p.Controls[0] as AuraCtrl;
                Aura aura = ctrl.GetData();
                monster.Auras.Add(aura);
            }
            LoadData();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addPowerButton_Click(object sender, EventArgs e)
        {
            TabPage p = new TabPage();
            MinionPowerCtrl ctrl = new MinionPowerCtrl(new MinionPower());
            p.Controls.Add(ctrl);
            powerTabCtrl.TabPages.Add(p);
        }

        private void removePowerButton_Click(object sender, EventArgs e)
        {
            powerTabCtrl.TabPages.Remove(powerTabCtrl.SelectedTab);
        }

        private void addAuraButton_Click(object sender, EventArgs e)
        {
            TabPage p = new TabPage();
            AuraCtrl ctrl = new AuraCtrl(new Aura());
            p.Controls.Add(ctrl);
            auraTabCtrl.TabPages.Add(p);
        }

        private void removeAuraButton_Click(object sender, EventArgs e)
        {
            auraTabCtrl.TabPages.Remove(auraTabCtrl.SelectedTab);
        }

        private void strScoreText_TextChanged(object sender, EventArgs e)
        {
            strModText.Text = Monster.GetMod(Convert.ToInt32(strScoreText.Text)).ToString();
        }

        private void conScoreText_TextChanged(object sender, EventArgs e)
        {
            conModText.Text = Monster.GetMod(Convert.ToInt32(conScoreText.Text)).ToString();
        }

        private void dexScoreText_TextChanged(object sender, EventArgs e)
        {
            dexModText.Text = Monster.GetMod(Convert.ToInt32(dexScoreText.Text)).ToString();
        }

        private void intScoreText_TextChanged(object sender, EventArgs e)
        {
            intModText.Text = Monster.GetMod(Convert.ToInt32(intScoreText.Text)).ToString();
        }

        private void wisScoreText_TextChanged(object sender, EventArgs e)
        {
            wisModText.Text = Monster.GetMod(Convert.ToInt32(wisScoreText.Text)).ToString();
        }

        private void chaScoreText_TextChanged(object sender, EventArgs e)
        {
            chaModText.Text = Monster.GetMod(Convert.ToInt32(chaScoreText.Text)).ToString();
        }
    }
}
