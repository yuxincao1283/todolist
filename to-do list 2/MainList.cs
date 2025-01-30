using System.Collections.Generic;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Collections;
using to_do_list_2.Properties;

public struct ColumnEntry
{
    public ColumnEntry(Panel parentPanel, Label title, Label date, Label divideLine, CheckBox box)
    {
        this.ParentPanel = parentPanel;
        this.Title = title;
        this.Date = date;
        this.DivideLine = divideLine;
        this.checkBox = box;
    }

    public Panel ParentPanel { get; private set; }
    public Label Title { get; private set; }    
    public Label Date { get; private set; }
    public Label DivideLine { get; private set; }
    public CheckBox checkBox { get; private set; }
}

public struct ListEntry
{
    public ListEntry(string title, string description, DateTime datetime, int repeats, int customDates)
    {
        Title = title;
        Description = description;
        DateTimeEntry = datetime;
        RepeatingDays = repeats;
        CustomDates = customDates;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DateTimeEntry { get; private set; }
    public int RepeatingDays { get; private set; }
    public int CustomDates { get; private set; }
    public int ID { get; set; }
}

namespace to_do_list_2
{
    public partial class MainList : Form
    {

        public MainList()
        {
            InitializeComponent();
        }


        /* #To-Do list
         * Text limit
         * Description when clicked
         * Remove columns correctly
         * Uploading to cloud
         * Save events locally
         * Make items dynamically changes sizes
         * User adding more categories
         * User changing category orders
         * User deleting categories
         * Setup oauth and upload to cloud
         * Figure out the bug thats causing the list to bug out when deleting entries while past entries is expanded
         * Adding handler for repeats
         * Add a times X next to the missing to show how many times you have missed this task
         * Make it so that repeated items is pinned instead of other items
         * Add tickbox for completed tasks, completed tasks will be moved to past tasks when expired
         * Add check to move item to past items automatically if an item is checked
         */

        private CreateItem ChildForm = null;


        private const int checkBoxSize = 16;
        private const int ButtonSize = 19;
        private const int spacing = 7;
        private const int EntrySpacing = 63;
        private const int textBoxSize = 20;

        private List<int> ButtonCount = new List<int>();

        private List<int> actualPanelHeight = new List<int> { 2, 2, 2 };
        private List<bool> panelStatus = new List<bool> { false, true, true };

        private List<System.Windows.Forms.Timer> timers;


        private int entryId = 0;

        private List<Panel> panels;

        private List<Label> labels;

        private List<PictureBox> ExpandButtons;
        private List<Tuple<int, int, int>> originalLocation;
        private List<Boolean> TimerStatus;
        private List<int> panelItemCount;

        private Dictionary<int, ListEntry> dictionaryListEntry = new Dictionary<int, ListEntry>();

        private SortedList<DateTime, List<int>> ListEntries = new SortedList<DateTime, List<int>>();
        private SortedList<DateTime, List<int>> MissedEntries = new SortedList<DateTime, List<int>>();
        private SortedList<DateTime, List<int>> PastEntries = new SortedList<DateTime, List<int>>(Comparer<DateTime>.Create(((a, b) => b.CompareTo(a))));

        private bool update_required = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            panelItemCount = new List<int> { 0, 0, 0 };
            TimerStatus = new List<Boolean> { false, false, false };
            panels = new List<Panel> { PanelPastTasks, PanelMissedTask, PanelTo_do };
            timers = new List<System.Windows.Forms.Timer> { pastTimer, missedTimer, pastTimer };
            PanelPastTasks.Tag = 0;
            PanelMissedTask.Tag = 1;
            PanelTo_do.Tag = 2;

            labels = new List<Label> { labelPastTask, labelMissedTasks, labelTodoTask };

            ExpandButtons = new List<PictureBox> { PastExpandButton, MissedExpandButton, TodoExpandButton };

            originalLocation = new List<Tuple<int, int, int>>();

            for (int i = 0; i < panels.Count; i++)
            {
                originalLocation.Add(new Tuple<int, int, int>(panels[i].Location.Y,
                                                              labels[i].Location.Y,
                                                              ExpandButtons[i].Location.Y));

            }



            for (int i = 0; i < 3; i++)
                ButtonCount.Add(0);


            //handle panel expansion for panels before and after
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ChildForm == null || this.ChildForm.IsDisposed)
            {
                this.ChildForm = new CreateItem();

                this.ChildForm.StartPosition = FormStartPosition.Manual;
                int parentRightEdge = this.Location.X + this.Width;
                int childFormY = this.Location.Y;

                this.ChildForm.Location = new Point(parentRightEdge, childFormY);

                this.ChildForm.whosmydaddy(this);

                this.ChildForm.Show();
            }
            else
            {
                int parentRightEdge = this.Location.X + this.Width;
                int childFormY = this.Location.Y;

                this.ChildForm.Location = new Point(parentRightEdge, childFormY);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void createEvent(object sender, EventArgs e)
        {
            //titleBox
            //descriptionBox

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void receiveEntry(ListEntry entryInfo)
        {
            //Console.WriteLine("ENTRY RECEIVED");

            entryInfo.ID = entryId;

            dictionaryListEntry.Add(entryId, entryInfo);

            if (ListEntries.ContainsKey(entryInfo.DateTimeEntry) == false)
            {
                List<int> newEntry = new List<int>();
                newEntry.Add(entryInfo.ID);
                ListEntries.Add(entryInfo.DateTimeEntry, newEntry);
            }
            else
            {
                ListEntries[entryInfo.DateTimeEntry].Add(entryInfo.ID);
            }

            panelItemCount[2]++;
            entryId++;

            update_required = true;
            //update layout
            this.updateLayout();
        }

        private void updateLayout()
        {

            resetLocation();

            Console.WriteLine("UPDATING LOCATION");
            Console.WriteLine(panels[1].Location);

            foreach (KeyValuePair<DateTime, List<int>> tmpPair in ListEntries)
            {
                foreach (int tmpEntry in tmpPair.Value)
                {
                    addEntry(PanelTo_do, dictionaryListEntry[tmpEntry]);
                }
            }

            Console.WriteLine(panels[1].Location);
            foreach (KeyValuePair<DateTime, List<int>> tmpPair in PastEntries)
            {
                foreach (int tmpEntry in tmpPair.Value)
                {
                    addEntry(PanelPastTasks, dictionaryListEntry[tmpEntry]);
                }
            }

            Console.WriteLine(panels[1].Location);

            foreach (KeyValuePair<DateTime, List<int>> tmpPair in MissedEntries)
            {
                foreach (int tmpEntry in tmpPair.Value)
                {
                    addEntry(PanelMissedTask, dictionaryListEntry[tmpEntry]);
                }
            }

            Console.WriteLine(panels[1].Location);
        }

        private void button_click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;

            if (clickedButton == null)
                return;

            KeyValuePair<ColumnEntry, ListEntry> itemPair = (KeyValuePair<ColumnEntry, ListEntry>)clickedButton.Tag;

            int curId = itemPair.Value.ID;

            DateTime key = itemPair.Value.DateTimeEntry;

            actualPanelHeight[(int)itemPair.Key.ParentPanel.Tag] -= EntrySpacing;

            Console.WriteLine($"panel index {itemPair.Key.ParentPanel.Tag}");

            if ((int)itemPair.Key.ParentPanel.Tag == 2)
            {
                ListEntries[key].Remove(curId);

                if (ListEntries[key].Count == 0)
                {
                    ListEntries.Remove(key);
                }

                if (PastEntries.ContainsKey(key) == false)
                {
                    PastEntries.Add(key, new List<int>());
                }

                PastEntries[key].Add(curId);

                panelItemCount[2]--;
                panelItemCount[0]++;
            }
            //delete everything
            //missing
            else if ((int)itemPair.Key.ParentPanel.Tag == 1)
            {
                MissedEntries[key].Remove(curId);

                if (MissedEntries[key].Count == 0)
                {
                    MissedEntries.Remove(key);
                }
                panelItemCount[1]--;
            }
            //past
            else if ((int)itemPair.Key.ParentPanel.Tag == 0)
            {
                PastEntries[key].Remove(curId);

                if (PastEntries[key].Count == 0)
                {
                    PastEntries.Remove(key);
                }

                panelItemCount[0]--;
            }

            //now remove column items
            update_required = true;
            //erase everything and call update layout
            updateLayout();
            //remove the key from list entries

        }

        private void CheckBox_checkchanged(object sender, EventArgs e)
        {

        }

        private void addEntry(Panel parentPanel, ListEntry entry)
        {
            Console.WriteLine("CREATED MEW ENTRY");
            String title = entry.Title;
            DateTime time = entry.DateTimeEntry;
            int entryId = entry.ID;
            bool repeating = false;

            if (entry.CustomDates != 0 || entry.RepeatingDays != 0)
            {
                repeating = true;
            }

            int panelIndex = (int)parentPanel.Tag;

            //this.PanelTo_do
            int base_spacing = ButtonCount[panelIndex] * EntrySpacing;

            ButtonCount[panelIndex]++;

            //add title on the top left
            Label titleBox = new Label();
            titleBox.Location = new System.Drawing.Point(spacing, base_spacing + spacing);
            titleBox.Text = title;
            titleBox.AutoSize = true;



            parentPanel.Controls.Add(titleBox);

            //and date time right below it
            Label DateAndTime = new Label();
            DateAndTime.Location = new Point(spacing, base_spacing + spacing * 2 + textBoxSize);
            DateAndTime.Text = time.ToString("dd/MM/yyyy   HH:mm");
            DateAndTime.AutoSize = true;
            //add label for underline below

            parentPanel.Controls.Add(DateAndTime);

            //Graphics g = PanelTo_do.CreateGraphics();
            //Pen pen = new Pen(Color.Black, 2);
            //g.DrawLine(pen, 0, 61, PanelTo_do.Width, 61);
            ////expand panel
            ///

            Label divideLine = new Label();
            divideLine.Location = new System.Drawing.Point(0, base_spacing + spacing * 3 + textBoxSize * 2);
            divideLine.Text = "";
            divideLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            divideLine.Height = 2;
            divideLine.Width = PanelTo_do.Width;

            parentPanel.Controls.Add(divideLine);

            CheckBox curBox = null;


            if (panelIndex > 0 && repeating)
            {
                curBox = new CheckBox();
                curBox.Size = new System.Drawing.Size(checkBoxSize, checkBoxSize);
                curBox.Location = new System.Drawing.Point(PanelTo_do.Width - ButtonSize - spacing + 1, base_spacing + spacing * 2 + textBoxSize + 2);
                curBox.Tag = new Tuple<int, int, DateTime>(panelIndex, entryId, time);
                curBox.CheckedChanged += CheckBox_checkchanged;
                parentPanel.Controls.Add(curBox);
            }


            Button curButton = new Button();
            curButton.Size = new System.Drawing.Size(ButtonSize, ButtonSize);
            curButton.Location = new System.Drawing.Point(PanelTo_do.Width - ButtonSize - spacing, base_spacing + spacing);
            curButton.FlatStyle = FlatStyle.System;
            curButton.Text = "X";

            ColumnEntry columnItems = new ColumnEntry(parentPanel, titleBox, DateAndTime, divideLine, curBox);
            int panelNumber = (int)parentPanel.Tag;

            curButton.Tag = new KeyValuePair<ColumnEntry, ListEntry>(columnItems, entry);
            curButton.Click += button_click;

            parentPanel.Controls.Add(curButton);
            //add button event to delete entry

            //create a tuple for the id of the current button
            //and the entry item, also include the item object
            //to be deleted





            actualPanelHeight[panelIndex] += EntrySpacing;

            if (panelStatus[panelIndex] == true)
            {
                parentPanel.Height += EntrySpacing;
            }


            //move panel down
            if (panelStatus[panelIndex] == true)
            {
                for (int i = panelIndex + 1; i < 3; i++)
                {
                    int lastX = panels[i].Location.X;
                    int lastY = panels[i].Location.Y;

                    panels[i].Location = new Point(lastX, lastY + EntrySpacing);

                    labels[i].Location = new Point(labels[i].Location.X,
                                                   labels[i].Location.Y + EntrySpacing);

                    ExpandButtons[i].Location = new Point(ExpandButtons[i].Location.X,
                                                          ExpandButtons[i].Location.Y + EntrySpacing);
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //for the earlist entry, check if they are expired, if they are, then put them into missing
        private void timerMinuteCheck_Tick(object sender, EventArgs e)
        {

            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine("CurTime: ");
            Console.WriteLine(currentDateTime);

            Console.WriteLine($"missing item count before: {panelItemCount[1]}");

            List<DateTime> KeysToBeRemoved = new List<DateTime>();

            bool changed = false;

            foreach (KeyValuePair<DateTime, List<int>> tmpEntry in ListEntries)
            {
                if (DateTime.Compare(currentDateTime, tmpEntry.Key) > 0)
                {
                    //current item is expired, remove it and move it into missed list
                    KeysToBeRemoved.Add(tmpEntry.Key);
                    changed = true;

                }
                else
                {
                    break;
                }
            }

            foreach (DateTime key in KeysToBeRemoved)
            {
                panelItemCount[1] += ListEntries[key].Count;
                panelItemCount[2] -= ListEntries[key].Count;
                //update layout here
                if (MissedEntries.ContainsKey(key) == false)
                {
                    MissedEntries.Add(key, ListEntries[key]);
                }
                else
                {
                    MissedEntries[key].AddRange(ListEntries[key]);
                }

                ListEntries.Remove(key);
            }

            List<DateTime> keysToBeFullyRemoved = new List<DateTime>();
            List<int> removed_ids = new List<int>();

            foreach (KeyValuePair<DateTime, List<int>> tmpEntry in PastEntries)
            {
                TimeSpan diff = currentDateTime - tmpEntry.Key;
                if (diff.TotalSeconds > 24 * 60 * 60)
                {
                    keysToBeFullyRemoved.Add(tmpEntry.Key);
                    foreach (int id in tmpEntry.Value)
                    {
                        dictionaryListEntry.Remove(id);
                    }
                }
            }

            foreach (DateTime key in keysToBeFullyRemoved)
            {

                panelItemCount[0] -= PastEntries[key].Count;

                //remove item in the dictionary and also past events
                PastEntries.Remove(key);

            }

            Console.WriteLine($"missing item count after: {panelItemCount[1]}");

            if (changed)
            {
                update_required = true;
                updateLayout();
            }
        }

        private void resetLocation()
        {
            Console.WriteLine("RESETTING LOCATION");
            for (int i = 0; i < 3; i++)
            {
                foreach (Control control in panels[i].Controls)
                {
                    control.Dispose();
                }

                panels[i].Controls.Clear();
                panels[i].Height = 2;
                ButtonCount[i] = 0;
                actualPanelHeight[i] = 2;
                panels[i].Location = new Point(panels[i].Location.X, originalLocation[i].Item1);
                labels[i].Location = new Point(labels[i].Location.X, originalLocation[i].Item2);
                ExpandButtons[i].Location = new Point(ExpandButtons[i].Location.X, originalLocation[i].Item3);

                if (i == 1)
                    Console.WriteLine(panels[i].Location);
            }

        }

        private void expandClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            int panelIndex = Int32.Parse((string)picture.Tag);

            int itemCount = panelItemCount[panelIndex];

            int panelHeight = 2;

            if (panelIndex == 0)
            {
                panelHeight += itemCount * EntrySpacing;
            }
            else if (panelIndex == 1)
            {
                panelHeight += itemCount * EntrySpacing;
            }
            else if (panelIndex == 2)
            {
                panelHeight += itemCount * EntrySpacing;
            }


            if (TimerStatus[panelIndex] == true)
            {
                picture.Image = Resources.frame1;
                timers[panelIndex].Stop();

                if (panelStatus[panelIndex] == true)
                {
                    updatePanelLocation(panelIndex, -(panels[panelIndex].Height - 2));

                    panels[panelIndex].Height = 2;
                    panelStatus[panelIndex] = false;
                }
                else
                {
                    updatePanelLocation(panelIndex, panelHeight - panels[panelIndex].Height);

                    panels[panelIndex].Height = actualPanelHeight[panelIndex];
                    panelStatus[panelIndex] = true;
                }

                TimerStatus[panelIndex] = false;

                return;
            }


            int animationSpeed = panelHeight / 28;


            Console.WriteLine($"panelCount {itemCount}");
            Console.WriteLine($"PanelHeight {panelHeight}");
            Console.WriteLine($"ANIMATION SPEED {animationSpeed}");

            timers[panelIndex].Tag = new Tuple<int, int, PictureBox, int>(panelIndex, animationSpeed, picture, panelHeight);

            //change image to expanding or collapsing

            if (panelStatus[panelIndex] == true)
            {
                picture.Image = Resources.collapse_speed;
            }
            else
            {
                picture.Image = Resources.expand_speed;
            }



            TimerStatus[panelIndex] = true;
            timers[panelIndex].Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //tag with animation speed

            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            int panelIndex = ((Tuple<int, int, PictureBox, int>)timer.Tag).Item1;
            int animationSpeed = ((Tuple<int, int, PictureBox, int>)timer.Tag).Item2;
            int panelHeight = ((Tuple<int, int, PictureBox, int>)timer.Tag).Item4;

            if (panelStatus[panelIndex] == true)
            {
                if ((panels[panelIndex].Height - animationSpeed) > 2)
                {
                    panels[panelIndex].Height -= animationSpeed;
                    updatePanelLocation(panelIndex, -animationSpeed);
                }
                else
                {
                    updatePanelLocation(panelIndex, -(panels[panelIndex].Height - 2));
                    panels[panelIndex].Height = 2;

                    panelStatus[panelIndex] = false;

                    PictureBox picture = ((Tuple<int, int, PictureBox, int>)timer.Tag).Item3;

                    picture.Image = Resources.frame1;

                    TimerStatus[panelIndex] = false;
                    timer.Stop();
                }

            }
            else
            {
                if ((panels[panelIndex].Height + animationSpeed) < panelHeight)
                {
                    panels[panelIndex].Height += animationSpeed;
                    updatePanelLocation(panelIndex, animationSpeed);
                }
                else
                {
                    updatePanelLocation(panelIndex, panelHeight - panels[panelIndex].Height);
                    panels[panelIndex].Height = actualPanelHeight[panelIndex];

                    panelStatus[panelIndex] = true;

                    PictureBox picture = ((Tuple<int, int, PictureBox, int>)timer.Tag).Item3;

                    picture.Image = Resources.frame1;


                    TimerStatus[panelIndex] = false;
                    timer.Stop();

                }
            }


        }

        private void updatePanelLocation(int panelIndex, int size)
        {
            if (size == 0)
                return;

            for (int i = panelIndex + 1; i < 3; i++)
            {
                int lastX = panels[i].Location.X;
                int lastY = panels[i].Location.Y;

                panels[i].Location = new Point(lastX, lastY + size);

                labels[i].Location = new Point(labels[i].Location.X,
                                               labels[i].Location.Y + size);

                ExpandButtons[i].Location = new Point(ExpandButtons[i].Location.X,
                                                      ExpandButtons[i].Location.Y + size);
            }
        }

        private void updatecheck_Tick(object sender, EventArgs e)
        {
            //insert api here
            update_required = false;
        }
    }


}
