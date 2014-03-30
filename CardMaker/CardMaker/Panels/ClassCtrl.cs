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
    public partial class ClassCtrl : UserControl
    {
        Class Clss;
        public ClassCtrl(Class c)
        {
            InitializeComponent();
            Clss = c;
            LoadData();
        }

        public ClassCtrl(out Class c)
        {
            InitializeComponent();
            c = new Class();
            Clss = c;
            LoadData();
        }

        public void LoadData()
        {
            nameText.Text = Clss.Name;
            levelText.Text = Clss.Level.ToString();
            raceText.Text = Clss.Race;
            classText.Text = Clss.CharacterClass;

            //Attributes
            LoadAttributes();

            //HP & Surges
            hpText.Text = Clss.HP.ToString();
            bloodiedText.Text = Clss.Bloodied.ToString();
            surgeText.Text = Clss.Surges.ToString();
            surgeValueText.Text = Clss.SurgeValue.ToString();

            //Save Modifier
            saveModText.Text = Clss.SaveModifiers;

            //Initiative
            initModText.Text = Clss.InitiativeModifiers.ToString();
            initText.Text = Clss.Inititive.ToString();

            //Movement
            movementModText.Text = Clss.MovementModifiers.ToString();
            movementText.Text = Clss.Movement.ToString();

            //Skills
            LoadSkills();

            //Defences
            LoadDefenses();

            //Features
            LoadFeatures();

            //Powers
            LoadPowers();

            //Attacks
            LoadAttacks();

            //Equipment();
            LoadItems();

            //Money
            LoadMoney();

            //Familiar
            LoadFamiliar();

            //Notes
            LoadNotes();
        }

        public void LoadAttributes()
        {
            strScoreText.Text = Clss.AttributesDict[Attributes.Strength].Score.ToString();
            conScoreText.Text = Clss.AttributesDict[Attributes.Constitution].Score.ToString();
            dexScoreText.Text = Clss.AttributesDict[Attributes.Dexterity].Score.ToString();
            intScoreText.Text = Clss.AttributesDict[Attributes.Intelligence].Score.ToString();
            wisScoreText.Text = Clss.AttributesDict[Attributes.Wisdom].Score.ToString();
            chaScoreText.Text = Clss.AttributesDict[Attributes.Charisma].Score.ToString();
            strModText.Text = Clss.AttributesDict[Attributes.Strength].GetMod().ToString();
            conModText.Text = Clss.AttributesDict[Attributes.Constitution].GetMod().ToString();
            dexModText.Text = Clss.AttributesDict[Attributes.Dexterity].GetMod().ToString();
            intModText.Text = Clss.AttributesDict[Attributes.Intelligence].GetMod().ToString();
            wisModText.Text = Clss.AttributesDict[Attributes.Wisdom].GetMod().ToString();
            chaModText.Text = Clss.AttributesDict[Attributes.Charisma].GetMod().ToString();
        }

        public void LoadSkills()
        {
            acrobaticsText.Text = Clss.SkillsDict[Skills.Acrobatics].ToString();
            arcanaText.Text = Clss.SkillsDict[Skills.Arcana].ToString();
            athleticsText.Text = Clss.SkillsDict[Skills.Athletics].ToString();
            bluffText.Text = Clss.SkillsDict[Skills.Bluff].ToString();
            diplomacyText.Text = Clss.SkillsDict[Skills.Diplomacy].ToString();
            dungeoneeringText.Text = Clss.SkillsDict[Skills.Dungeoneering].ToString();
            enduranceText.Text = Clss.SkillsDict[Skills.Endurance].ToString();
            healText.Text = Clss.SkillsDict[Skills.Heal].ToString();
            historyText.Text = Clss.SkillsDict[Skills.History].ToString();
            insightText.Text = Clss.SkillsDict[Skills.Insight].ToString();
            intimidateText.Text = Clss.SkillsDict[Skills.Intimidate].ToString();
            natureText.Text = Clss.SkillsDict[Skills.Nature].ToString();
            perceptionText.Text = Clss.SkillsDict[Skills.Perception].ToString();
            religionText.Text = Clss.SkillsDict[Skills.Religion].ToString();
            stealthText.Text = Clss.SkillsDict[Skills.Stealth].ToString();
            streetwiseText.Text = Clss.SkillsDict[Skills.Streetwise].ToString();
            thieveryText.Text = Clss.SkillsDict[Skills.Thievery].ToString();
        }

        public void LoadDefenses()
        {
            DefenceStat ac = Clss.DefencesDict[Defences.Armour_Class];
            acText.Text = ac.Defence.ToString();
            acModText.Text = ac.Modifiers;
            DefenceStat fort = Clss.DefencesDict[Defences.Fortitude];
            fortText.Text = fort.Defence.ToString();
            fortModText.Text = fort.Modifiers;
            DefenceStat refl = Clss.DefencesDict[Defences.Reflex];
            refText.Text = refl.Defence.ToString();
            refModText.Text = refl.Modifiers;
            DefenceStat will = Clss.DefencesDict[Defences.Will];
            willText.Text = will.Defence.ToString();
            willModText.Text = will.Modifiers;
        }

        public void LoadFeatures()
        {
            raceFeatureTabCtrl.TabPages.Clear();
            classFeatureTabCtrl.TabPages.Clear();
            featTabCtrl.TabPages.Clear();
            backgroundFeatureTabCtrl.TabPages.Clear();
            foreach (Feature feat in Clss.RaceFeatures)
            {
                TabPage p = new TabPage();
                p.AutoScroll = true;
                p.Text = feat.Name;
                FeatureCtrl<Feature> ctrl = new FeatureCtrl<Feature>(feat);
                p.Controls.Add(ctrl);
                raceFeatureTabCtrl.TabPages.Add(p);
            }
            foreach (Feature feat in Clss.ClassFeatures)
            {
                TabPage p = new TabPage();
                p.Text = feat.Name;
                p.AutoScroll = true;
                FeatureCtrl<Feature> ctrl = new FeatureCtrl<Feature>(feat);
                p.Controls.Add(ctrl);
                classFeatureTabCtrl.TabPages.Add(p);
            }
            foreach (Feature feat in Clss.Feats)
            {
                TabPage p = new TabPage();
                p.Text = feat.Name;
                p.AutoScroll = true;
                FeatureCtrl<Feature> ctrl = new FeatureCtrl<Feature>(feat);
                p.Controls.Add(ctrl);
                featTabCtrl.TabPages.Add(p);
            }
            foreach (Feature feat in Clss.BackgroundFeatures)
            {
                TabPage p = new TabPage();
                p.Text = feat.Name;
                p.AutoScroll = true;
                FeatureCtrl<Feature> ctrl = new FeatureCtrl<Feature>(feat);
                p.Controls.Add(ctrl);
                backgroundFeatureTabCtrl.TabPages.Add(p);
            }
        }

        public void LoadPowers()
        {
            atWillTabCtrl.TabPages.Clear();
            encounterTabCtrl.TabPages.Clear();
            dailyTabCtrl.TabPages.Clear();
            foreach (BasicPower power in Clss.AtWillPowers)
            {
                TabPage p = new TabPage();
                p.Text = power.PowerName;
                p.AutoScroll = true;
                FeatureCtrl<BasicPower> ctrl = new FeatureCtrl<BasicPower>(power);
                p.Controls.Add(ctrl);
                atWillTabCtrl.TabPages.Add(p);
            }
            foreach (BasicPower power in Clss.EncounterPowers)
            {
                TabPage p = new TabPage();
                p.Text = power.PowerName;
                p.AutoScroll = true;
                FeatureCtrl<BasicPower> ctrl = new FeatureCtrl<BasicPower>(power);
                p.Controls.Add(ctrl);
                encounterTabCtrl.TabPages.Add(p);
            }
            foreach (BasicPower power in Clss.DailyPowers)
            {
                TabPage p = new TabPage();
                p.Text = power.PowerName;
                p.AutoScroll = true;
                FeatureCtrl<BasicPower> ctrl = new FeatureCtrl<BasicPower>(power);
                p.Controls.Add(ctrl);
                dailyTabCtrl.TabPages.Add(p);
            }

        }

        public void LoadAttacks()
        {
            attackTabCtrl.TabPages.Clear();
            foreach (Attack attack in Clss.Attacks)
            {
                TabPage p = new TabPage();
                p.Text = attack.Name;
                p.AutoScroll = true;
                AttackCtrl ctrl = new AttackCtrl(attack);
                p.Controls.Add(ctrl);
                attackTabCtrl.TabPages.Add(p);
            }
        }

        public void LoadItems()
        {
            itemTabCtrl.TabPages.Clear();
            foreach (BasicItem item in Clss.Items)
            {
                TabPage p = new TabPage();
                p.Text = item.Name;
                p.AutoScroll = true;
                FeatureCtrl<BasicItem> ctrl = new FeatureCtrl<BasicItem>(item);
                p.Controls.Add(ctrl);
                itemTabCtrl.TabPages.Add(p);
            }
        }

        public void LoadMoney()
        {
            platText.Text = Clss.CharacterMoney.Platinum.ToString();
            goldText.Text = Clss.CharacterMoney.Gold.ToString();
            silverText.Text = Clss.CharacterMoney.Silver.ToString();
            copperText.Text = Clss.CharacterMoney.Copper.ToString();
        }

        public void LoadFamiliar()
        {
            familiarNameText.Text = Clss.CharacterFamiliar.Name;
            familiarDescText.Text = Clss.CharacterFamiliar.Description;
            familiarSensesText.Text = Clss.CharacterFamiliar.Senses;
            familiarSpeedText.Text = Clss.CharacterFamiliar.Speed;
            familiarTypeText.Text = Clss.CharacterFamiliar.Type;
            familiarConstantBenefitsText.Text = Clss.CharacterFamiliar.ConstantBenefits;
            familiarActiveBenefitsText.Text = Clss.CharacterFamiliar.ActiveBenefits;
        }

        public void LoadNotes()
        {
            notesTabCtrl.TabPages.Clear();
            foreach (string s in Clss.Notes)
            {
                TabPage p = new TabPage();
                TextBox t = new TextBox();
                p.Controls.Add(t);
                t.Dock = DockStyle.Fill;
                t.Text = s;
                t.Multiline = true;
                notesTabCtrl.TabPages.Add(p);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Main
                Clss.Name = nameText.Text;
                Clss.Level = Convert.ToInt32(levelText.Text);
                Clss.Race = raceText.Text;
                Clss.CharacterClass = classText.Text;

                //Attributes
                Clss.AttributesDict[Attributes.Strength].Score = Convert.ToInt32(strScoreText.Text);
                Clss.AttributesDict[Attributes.Constitution].Score = Convert.ToInt32(conScoreText.Text);
                Clss.AttributesDict[Attributes.Dexterity].Score = Convert.ToInt32(dexScoreText.Text);
                Clss.AttributesDict[Attributes.Intelligence].Score = Convert.ToInt32(intScoreText.Text);
                Clss.AttributesDict[Attributes.Wisdom].Score = Convert.ToInt32(wisScoreText.Text);
                Clss.AttributesDict[Attributes.Charisma].Score = Convert.ToInt32(chaScoreText.Text);

                //HP & Surges
                Clss.HP = Convert.ToInt32(hpText.Text);
                Clss.Bloodied = Convert.ToInt32(bloodiedText.Text);
                Clss.Surges = Convert.ToInt32(surgeText.Text);
                Clss.SurgeValue = Convert.ToInt32(surgeValueText.Text);

                //Save Modifiers
                Clss.SaveModifiers = saveModText.Text;

                //Initiative
                Clss.Inititive = Convert.ToInt32(initText.Text);
                Clss.InitiativeModifiers = initModText.Text;

                //Movement
                Clss.Movement = Convert.ToInt32(movementText.Text);
                Clss.MovementModifiers = movementModText.Text;

                //Skills
                Clss.SkillsDict[Skills.Acrobatics] = Convert.ToInt32(acrobaticsText.Text);
                Clss.SkillsDict[Skills.Arcana] = Convert.ToInt32(arcanaText.Text);
                Clss.SkillsDict[Skills.Athletics] = Convert.ToInt32(athleticsText.Text);
                Clss.SkillsDict[Skills.Bluff] = Convert.ToInt32(bluffText.Text);
                Clss.SkillsDict[Skills.Diplomacy] = Convert.ToInt32(diplomacyText.Text);
                Clss.SkillsDict[Skills.Dungeoneering] = Convert.ToInt32(dungeoneeringText.Text);
                Clss.SkillsDict[Skills.Endurance] = Convert.ToInt32(enduranceText.Text);
                Clss.SkillsDict[Skills.Heal] = Convert.ToInt32(healText.Text);
                Clss.SkillsDict[Skills.History] = Convert.ToInt32(historyText.Text);
                Clss.SkillsDict[Skills.Insight] = Convert.ToInt32(insightText.Text);
                Clss.SkillsDict[Skills.Intimidate] = Convert.ToInt32(intimidateText.Text);
                Clss.SkillsDict[Skills.Nature] = Convert.ToInt32(natureText.Text);
                Clss.SkillsDict[Skills.Perception] = Convert.ToInt32(perceptionText.Text);
                Clss.SkillsDict[Skills.Religion] = Convert.ToInt32(religionText.Text);
                Clss.SkillsDict[Skills.Stealth] = Convert.ToInt32(stealthText.Text);
                Clss.SkillsDict[Skills.Streetwise] = Convert.ToInt32(streetwiseText.Text);
                Clss.SkillsDict[Skills.Thievery] = Convert.ToInt32(thieveryText.Text);

                //Defences
                Clss.DefencesDict[Defences.Armour_Class].Defence = Convert.ToInt32(acText.Text);
                Clss.DefencesDict[Defences.Fortitude].Defence = Convert.ToInt32(fortText.Text);
                Clss.DefencesDict[Defences.Reflex].Defence = Convert.ToInt32(refText.Text);
                Clss.DefencesDict[Defences.Will].Defence = Convert.ToInt32(willText.Text);

                Clss.DefencesDict[Defences.Armour_Class].Modifiers = acModText.Text;
                Clss.DefencesDict[Defences.Fortitude].Modifiers = fortModText.Text;
                Clss.DefencesDict[Defences.Reflex].Modifiers = refModText.Text;
                Clss.DefencesDict[Defences.Will].Modifiers = willModText.Text;

                //Features
                Clss.RaceFeatures.Clear();
                foreach (TabPage p in raceFeatureTabCtrl.TabPages)
                {
                    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                    RaceFeature f = ctrl.GetData() as RaceFeature;
                    Clss.RaceFeatures.Add(f);
                }
                Clss.ClassFeatures.Clear();
                foreach (TabPage p in classFeatureTabCtrl.TabPages)
                {
                    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                    ClassFeature f = ctrl.GetData() as ClassFeature;
                    Clss.ClassFeatures.Add(f);
                }
                Clss.Feats.Clear();
                foreach (TabPage p in featTabCtrl.TabPages)
                {
                    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                    Feat f = ctrl.GetData() as Feat;
                    Clss.Feats.Add(f);
                }
                Clss.BackgroundFeatures.Clear();
                foreach (TabPage p in backgroundFeatureTabCtrl.TabPages)
                {
                    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                    BackgroundFeature f = ctrl.GetData() as BackgroundFeature;
                    Clss.BackgroundFeatures.Add(f);
                }

                //Powers
                Clss.AtWillPowers.Clear();
                foreach (TabPage p in atWillTabCtrl.TabPages)
                {
                    FeatureCtrl<BasicPower> ctrl = p.Controls[0] as FeatureCtrl<BasicPower>;
                    BasicPower f = ctrl.GetData() as BasicPower;
                    Clss.AtWillPowers.Add(f);
                }
                Clss.EncounterPowers.Clear();
                foreach (TabPage p in encounterTabCtrl.TabPages)
                {
                    FeatureCtrl<BasicPower> ctrl = p.Controls[0] as FeatureCtrl<BasicPower>;
                    BasicPower f = ctrl.GetData() as BasicPower;
                    Clss.EncounterPowers.Add(f);
                }
                Clss.DailyPowers.Clear();
                foreach (TabPage p in dailyTabCtrl.TabPages)
                {
                    FeatureCtrl<BasicPower> ctrl = p.Controls[0] as FeatureCtrl<BasicPower>;
                    BasicPower f = ctrl.GetData() as BasicPower;
                    Clss.DailyPowers.Add(f);
                }

                //Attacks
                Clss.Attacks.Clear();
                foreach (TabPage p in attackTabCtrl.TabPages)
                {
                    AttackCtrl ctrl = p.Controls[0] as AttackCtrl;
                    Attack f = ctrl.GetData() as Attack;
                    Clss.Attacks.Add(f);
                }

                //Equipment
                Clss.Items.Clear();
                foreach (TabPage p in itemTabCtrl.TabPages)
                {
                    FeatureCtrl<BasicItem> ctrl = p.Controls[0] as FeatureCtrl<BasicItem>;
                    BasicItem f = ctrl.GetData() as BasicItem;
                    Clss.Items.Add(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private static void updateListFromTabs<T, Ctrl_Type>(List<T> list, TabControl ctrl) where Ctrl_Type : Control
        {
            list.Clear();
            foreach (TabPage p in ctrl.TabPages)
            {
                Ctrl_Type inner_ctrl = p.Controls[0] as Ctrl_Type;
                T f = inner_ctrl.GetData() as T;
                list.Add(f);
            }
        }
    }
}
