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
                updateListFromTabs<Feature, RaceFeature, FeatureCtrl<Feature>>(Clss.RaceFeatures, raceFeatureTabCtrl);
                updateListFromTabs<Feature, ClassFeature, FeatureCtrl<Feature>>(Clss.ClassFeatures, classFeatureTabCtrl);
                updateListFromTabs<Feature, Feat, FeatureCtrl<Feature>>(Clss.Feats, featTabCtrl);
                updateListFromTabs<Feature, BackgroundFeature, FeatureCtrl<Feature>>(Clss.BackgroundFeatures, backgroundFeatureTabCtrl); 
                //Clss.RaceFeatures.Clear();
                //foreach (TabPage p in raceFeatureTabCtrl.TabPages)
                //{
                //    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                //    RaceFeature f = (RaceFeature)(ctrl.GetData());
                //    Clss.RaceFeatures.Add(f);
                //}
                //Clss.ClassFeatures.Clear();
                //foreach (TabPage p in classFeatureTabCtrl.TabPages)
                //{
                //    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                //    ClassFeature f = ctrl.GetData() as ClassFeature;
                //    Clss.ClassFeatures.Add(f);
                //}
                //Clss.Feats.Clear();
                //foreach (TabPage p in featTabCtrl.TabPages)
                //{
                //    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                //    Feat f = ctrl.GetData() as Feat;
                //    Clss.Feats.Add(f);
                //}
                //Clss.BackgroundFeatures.Clear();
                //foreach (TabPage p in backgroundFeatureTabCtrl.TabPages)
                //{
                //    FeatureCtrl<Feature> ctrl = p.Controls[0] as FeatureCtrl<Feature>;
                //    BackgroundFeature f = ctrl.GetData() as BackgroundFeature;
                //    Clss.BackgroundFeatures.Add(f);
                //}

                //Powers
                updateListFromTabs<BasicPower, BasicPower, FeatureCtrl<BasicPower>>(Clss.AtWillPowers, atWillTabCtrl);
                updateListFromTabs<BasicPower, BasicPower, FeatureCtrl<BasicPower>>(Clss.EncounterPowers, encounterTabCtrl);
                updateListFromTabs<BasicPower, BasicPower, FeatureCtrl<BasicPower>>(Clss.DailyPowers, dailyTabCtrl);

                //Attacks
                updateListFromTabs<Attack, Attack, AttackCtrl>(Clss.Attacks, attackTabCtrl);

                //Equipment
                updateListFromTabs<BasicItem, BasicItem, FeatureCtrl<BasicItem>>(Clss.Items, itemTabCtrl);

                //Money
                Clss.CharacterMoney.Platinum = Convert.ToInt32(platText.Text);
                Clss.CharacterMoney.Gold = Convert.ToInt32(goldText.Text);
                Clss.CharacterMoney.Silver = Convert.ToInt32(silverText.Text);
                Clss.CharacterMoney.Copper = Convert.ToInt32(copperText.Text);

                //Familiar
                Clss.CharacterFamiliar.Name = familiarNameText.Text;
                Clss.CharacterFamiliar.Description = familiarDescText.Text;
                Clss.CharacterFamiliar.Senses = familiarSensesText.Text;
                Clss.CharacterFamiliar.Speed = familiarSpeedText.Text;
                Clss.CharacterFamiliar.Type = familiarTypeText.Text;
                Clss.CharacterFamiliar.ConstantBenefits = familiarConstantBenefitsText.Text;
                Clss.CharacterFamiliar.ActiveBenefits = familiarActiveBenefitsText.Text;

                //Notes
                Clss.Notes.Clear();
                foreach (TabPage p in notesTabCtrl.TabPages)
                {
                    TextBox b = p.Controls[0] as TextBox;
                    Clss.Notes.Add(b.Text);
                }
                LoadData();
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

        private static void updateListFromTabs<Parent, Child, Ctrl_Type>(List<Child> list, TabControl ctrl) where Ctrl_Type : Control, IReturnsData<Parent> where Child : Parent
        {
            list.Clear();
            foreach (TabPage p in ctrl.TabPages)
            {
                Ctrl_Type inner_ctrl = p.Controls[0] as Ctrl_Type;
                Child f = (Child)(inner_ctrl.GetData());
                list.Add(f);
            }
        }

        private void updateStrScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(strScoreText.Text) - 10) / 2;
            strModText.Text = mod.ToString();
        }

        private void updateConScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(conScoreText.Text) - 10) / 2;
            conModText.Text = mod.ToString();
        }

        private void updateDexScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(dexScoreText.Text) - 10) / 2;
            dexModText.Text = mod.ToString();
        }

        private void updateIntScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(intScoreText.Text) - 10) / 2;
            intModText.Text = mod.ToString();
        }

        private void updateWisScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(wisScoreText.Text) - 10) / 2;
            wisModText.Text = mod.ToString();
        }

        private void updateChaScore(object sender, EventArgs e)
        {
            int mod = (Convert.ToInt32(chaScoreText.Text) - 10) / 2;
            chaModText.Text = mod.ToString();
        }

        private void addRaceFeature_Click(object sender, EventArgs e)
        {
            RaceFeature f = new RaceFeature();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new FeatureCtrl<Feature>(f));
            raceFeatureTabCtrl.TabPages.Add(p);
        }

        private void addClassFeature_Click(object sender, EventArgs e)
        {
            ClassFeature f = new ClassFeature();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new FeatureCtrl<Feature>(f));
            classFeatureTabCtrl.TabPages.Add(p);
        }

        private void addFeat_Click(object sender, EventArgs e)
        {
            Feat f = new Feat();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new FeatureCtrl<Feature>(f));
            featTabCtrl.TabPages.Add(p);
        }

        private void addBackgroundFeature_Click(object sender, EventArgs e)
        {
            BackgroundFeature f = new BackgroundFeature();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new FeatureCtrl<Feature>(f));
            backgroundFeatureTabCtrl.TabPages.Add(p);
        }

        private void removeRaceFeature_Click(object sender, EventArgs e)
        {
            TabPage p = raceFeatureTabCtrl.SelectedTab;
            //FeatureCtrl<Feature> f = p.Controls[0] as FeatureCtrl<Feature>;
            //RaceFeature feat = f.GetData() as RaceFeature;
            //Clss.RaceFeatures.Remove(feat);
            raceFeatureTabCtrl.TabPages.Remove(p);
        }

        private void removeClassFeature_Click(object sender, EventArgs e)
        {
            TabPage p = classFeatureTabCtrl.SelectedTab;
            //FeatureCtrl<Feature> f = p.Controls[0] as FeatureCtrl<Feature>;
            //ClassFeature feat = f.GetData() as ClassFeature;
            //Clss.ClassFeatures.Remove(feat);
            classFeatureTabCtrl.TabPages.Remove(p);
        }

        private void removeFeat_Click(object sender, EventArgs e)
        {
            TabPage p = featTabCtrl.SelectedTab;
            //FeatureCtrl<Feature> f = p.Controls[0] as FeatureCtrl<Feature>;
            //Feat feat = f.GetData() as Feat;
            //Clss.Feats.Remove(feat);
            featTabCtrl.TabPages.Remove(p);
        }

        private void removeBackgroundFeature_Click(object sender, EventArgs e)
        {
            TabPage p = backgroundFeatureTabCtrl.SelectedTab;
            //FeatureCtrl<Feature> f = p.Controls[0] as FeatureCtrl<Feature>;
            //BackgroundFeature feat = f.GetData() as BackgroundFeature;
            //Clss.BackgroundFeatures.Remove(feat);
            backgroundFeatureTabCtrl.TabPages.Remove(p);
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            TabPage p = new TabPage();
            TextBox t = new TextBox();
            t.Dock = DockStyle.Fill;
            t.Multiline = true;
            p.Controls.Add(t);
            notesTabCtrl.TabPages.Add(p);
        }

        private void removeNoteButton_Click(object sender, EventArgs e)
        {
            notesTabCtrl.TabPages.Remove(notesTabCtrl.SelectedTab);
        }

        private void addAtWillButton_Click(object sender, EventArgs e)
        {
            BasicPower f = new BasicPower();
            TabPage p = new TabPage();
            p.Text = f.PowerName;
            p.Controls.Add(new FeatureCtrl<BasicPower>(f));
            atWillTabCtrl.TabPages.Add(p);
        }

        private void addEncounterButton_Click(object sender, EventArgs e)
        {
            BasicPower f = new BasicPower();
            TabPage p = new TabPage();
            p.Text = f.PowerName;
            p.Controls.Add(new FeatureCtrl<BasicPower>(f));
            encounterTabCtrl.TabPages.Add(p);
        }

        private void addDailyButton_Click(object sender, EventArgs e)
        {
            BasicPower f = new BasicPower();
            TabPage p = new TabPage();
            p.Text = f.PowerName;
            p.Controls.Add(new FeatureCtrl<BasicPower>(f));
            dailyTabCtrl.TabPages.Add(p);
        }

        private void addAttackButton_Click(object sender, EventArgs e)
        {
            Attack f = new Attack();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new AttackCtrl(f));
            attackTabCtrl.TabPages.Add(p);
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            BasicItem f = new BasicItem();
            TabPage p = new TabPage();
            p.Text = f.Name;
            p.Controls.Add(new FeatureCtrl<BasicItem>(f));
            itemTabCtrl.TabPages.Add(p);
        }

        private void removeAtWillButton_Click(object sender, EventArgs e)
        {
            atWillTabCtrl.TabPages.Remove(atWillTabCtrl.SelectedTab);
        }

        private void removeEncounterButton_Click(object sender, EventArgs e)
        {
            encounterTabCtrl.TabPages.Remove(encounterTabCtrl.SelectedTab);
        }

        private void removeDailyButton_Click(object sender, EventArgs e)
        {
            dailyTabCtrl.TabPages.Remove(dailyTabCtrl.SelectedTab);
        }

        private void removeAttackButton_Click(object sender, EventArgs e)
        {
            attackTabCtrl.TabPages.Remove(attackTabCtrl.SelectedTab);
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            itemTabCtrl.TabPages.Remove(itemTabCtrl.SelectedTab);
        }
    }
}
