using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Fire_Emblem_Fates_Convoy_Editor
{
    public partial class ConvoyEditor : Form
    {
        private byte[] save;
        private int convoyOffset;
        private Item[] items;
        private short itemCount;
        private DataGridViewCellStyle grayCellStyle = new DataGridViewCellStyle()
        {
            BackColor = Color.LightGray
        };
        private bool dataLoaded = false;

        private const int MaxItem = 500;
        private const int Magic = 0x5452414E;

        #region Item class
        private class Item
        {
            private byte[] itemBytes;
            public static readonly string[] ItemNameList = { "None",
                "Bronze Sword", "Iron Sword", "Steel Sword", "Silver Sword",
                "Brave Sword", "Iron Kukri", "Steel Kukri", "Silver Kukri",
                "Armorslayer", "Wyrmslayer", "Killing Edge", "Levin Sword",
                "Ganglari", "Siegfried", "Bottle", "Umbrella", "Nohrian Blade",
                "Leo's Iceblade", "Selena's Blade", "Laslow's Blade",
                "Brass Katana", "Iron Katana", "Steel Katana", "Silver Katana",
                "Venge Katana", "Iron Katti", "Steel Katti", "Silver Katti",
                "Kodachi", "Wakizashi", "Axe Splitter", "Dual Katana",
                "Practice Katana", "Spirit Katana", "Hagakure Blade", "Yato",
                "Noble Yato", "Blazing Yato", "Grim Yato", "Shadow Yato",
                "Alpha Yato", "Omega Yato", "Raijinto", "Daikon Radish",
                "Parasol", "Raider Katana", "Sunrise Katana", "Takumi's Shinai",
                "Hana's Katana", "Hinata's Katana", "Bronze Lance", "Iron Lance",
                "Steel Lance", "Silver Lance", "Brave Lance", "Iron Javelin",
                "Steel Javelin", "Silver Javelin", "Javelin", "Spear",
                "Beast Killer", "Killer Lance", "Blessed Lance", "Broom",
                "Stick", "Hexlock Spear", "Xander's Lance", "Effie's Lance",
                "Peri's Lance", "Brass Naginata", "Iron Naginata", 
                "Steel Naginata", "Silver Naginata", "Venge Naginata",
                "Iron Nageyari", "Steel Nageyari", "Silver Nageyari",
                "Swordcatcher", "Dual Naginata", "Guard Naginata",
                "Bolt Naginata", "Waterwheel", "Bamboo Pole", "Pine Branch", 
                "Raider Naginata", "Bold Naginata", "Hinoka's Spear",
                "Subaki's Pike", "Oboro's Spear", "Bronze Axe", "Iron Axe",
                "Steel Axe", "Silver Axe", "Brave Axe", "Iron Star Axe", 
                "Steel Star Axe", "Silver Star Axe", "Hand Axe", "Tomahawk",
                "Hammer", "Bolt Axe", "Killer Axe", "Aurgelmir", "Bölverk",
                "Frying Pan", "Bone Axe", "Raider Axe", "Berserker's Axe",
                "Camilla's Axe", "Arthur's Axe", "Beruka's Axe", "Brass Club",
                "Iron Club", "Steel Club", "Silver Club", "Venge Club",
                "Iron Mace", "Steel Mace", "Silver Mace", "Throwing Club",
                "Battering Club", "Pike-Ruin Club", "Dual Club", "Great Club",
                "Carp Streamer", "Hoe", "Adamant Club", "Rinkah's Club",
                "Ryoma's Club", "Fuga's Club", "Bronze Dagger", "Iron Dagger",
                "Steel Dagger", "Silver Dagger", "Soldier's Knife", "Fruit Knife",
                "Hunter's Knife", "Kris Knife", "Quill Pen", "Stale Bread",
                "Raider Knife", "Votive Candle", "Sacrificial Knife",
                "Felicia's Plate", "Jakob's Tray", "Brass Shuriken",
                "Iron Shuriken", "Steel Shuriken", "Silver Shuriken",
                "Spy's Shuriken", "Dual Shuriken", "Sting Shuriken",
                "Barb Shuriken", "Flame Shuriken", "Chakram", "Chopstick",
                "Hair Pin", "Caltrop", "Kaze's Needle", "Saizo's Star", 
                "Kagero's Dart", "Bronze Bow", "Iron Bow", "Steel Bow",
                "Silver Bow", "Crescent Bow", "Iron Shortbow", "Steel Shortbow",
                "Silver Shortbow", "Mini Bow", "Killer Bow", "Blessed Bow",
                "Shining Bow", "Rubber Bow", "Violin Bow", "Cupid Bow",
                "Hunter's Bow", "Anna's Bow", "Niles's Bow", "Brass Yumi",
                "Iron Yumi", "Steel Yumi", "Silver Yumi", "Spy's Yumi",
                "Iron Hankyu", "Steel Hankyu", "Silver Hankyu", "Dual Yumi",
                "Illusory Yumi", "Surefire Yumi", "Pursuer", "Fujin Yumi",
                "Fujin Yumi", "Skadi", "Bamboo Yumi", "Harp Yumi",
                "Raider Yumi", "Spellbane Yumi", "Sidelong Yumi",
                "Mikoto's Yumi", "Setsuna's Yumi", "Fire", "Thunder",
                "Fimbulvetr", "Ragnarok", "Ginnungagap", "Lightning", "Mjölnir",
                "Nosferatu", "Excalibur", "Brynhildr", "Ember", "Missiletainn",
                "Disrobing Gale", "Speed Thunder", "Moonlight", "Iago's Tome",
                "Odin's Grimoire", "Rat Spirit", "Ox Spirit", "Tiger Spirit",
                "Rabbit Spirit", "Dragon Spirit", "Calamity Gate", "Snake Spirit",
                "Horse Spirit", "Sheep Spirit", "Paper", "Malevolent Text",
                "Monkey Spirit", "Bird Spirit", "Ink Painting", "Izana's Scroll",
                "Heal", "Mend", "Physic", "Recover", "Fortify", "Freeze",
                "Enfeeble", "Entrap", "Entrap (2)", "Bifröst", "Candy Cane",
                "Mushroom Staff", "Bouquet Staff", "Elise's Staff",
                "Lilith's Staff", "Bloom Festal", "Sun Festal", "Wane Festal",
                "Moon Festal", "Great Festal", "Rescue", "Silence", "Hexing Rod",
                "Lantern", "Dumpling Rod", "Bamboo Branch", "Sakura's Rod",
                "Purification Rod", "Dragonstone", "Dragonstone+", "Beaststone",
                "Beastrune", "Beaststone+", "Draconic Rage", "Dark Breath",
                "Invisible's Breath", "Invisible's Breath (2)", "Shackled Fist",
                "Gauntlet", "Rock", "Massive Rock", "Astral Breath",
                "Astral Blessing", "Vulnerary", "Concoction", "Elixir",
                "HP Tonic", "Strength Tonic", "Magic Tonic", "Skill Tonic",
                "Speed Tonic", "Luck Tonic", "Defense Tonic",
                "Resistance Tonic", "Azura's Salve", "Gunter's Potion",
                "Asugi's Confect", "Rainbow Tonic", "Seed of Trust",
                "Allegro Harp", "Shell Horn", "Saw", "Big Saw", "Door Key",
                "Chest Key", "Master Key", "Seraph Robe", "Energy Drop",
                "Spirit Dust", "Secret Book", "Speedwing", "Goddess Icon",
                "Dracoshield", "Talisman", "Dragon Herbs", "Boots",
                "Arms Scroll", "Master Seal", "Heart Seal", "Partner Seal",
                "Friendship Seal", "Eternal Seal", "Dread Scroll", "Ebon Wing",
                "Ganglari", "Gold Bar", "Battle Seal", "Visitation Seal",
                "Offspring Seal", "Sighting Lens", "Witch's Mark", "Paragon",
                "Armor Shield", "Beast Shield", "Winged Shield", "Point Blank",
                "Bold Stance", "Strengthtaker", "Magictaker", "Skilltaker",
                "Speedtaker", "Lucktaker", "Defensetaker", "Resistancetaker",
                "Master Emblem", "Falchion", "Ragnell", "Parallel Falchion",
                "Thoron", "Marth's Spatha", "Ike's Backup", "Lucina's Estoc",
                "Robin's Primer", "1000G", "2000G", "3000G", "5000G", "7000G",
                "10000G", "20000G", "Obstacle", "Pebble", "Hero's Brand",
                "Exalt's Brand", "", "Fell Brand", "First Blood", "",
                "Vanguard Brand", "Heavy Blade", "Veteran Intuition", "Aether",
                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "", "", "Warp" };
            public static readonly byte[] BaseUses = { 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 15, 5, 5, 2,
                4, 4, 2, 1, 1, 5, 5, 3, 1, 1, 20, 15, 5, 5, 2, 2, 4, 3, 5, 3, 3,
                10, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 2, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 1 };
            public static readonly short[] SortedItemList = { 0x0, 0x160, 0x15B,
                0x161, 0x15C, 0x15D, 0x15E, 0x15F, 0x7F, 0x16D, 0x125, 0x29,
                0xB2, 0x146, 0x9, 0x136, 0x6E, 0x114, 0x113, 0x122, 0x67, 0x1F,
                0x120, 0x103, 0x53, 0xC3, 0x99, 0x79, 0x140, 0x3D, 0x147, 0x109,
                0x108, 0x10A, 0x6C, 0x6F, 0xF3, 0x128, 0xE7, 0x26, 0xAC, 0x3F,
                0xF9, 0x56, 0x14A, 0x65, 0x51, 0x68, 0x6A, 0x135, 0xF, 0xF6,
                0x70, 0x15, 0x46, 0x92, 0xB4, 0x5E, 0x37, 0x5, 0x5A, 0xA2, 0x83,
                0x33, 0x1, 0x40, 0xD3, 0xE0, 0x9E, 0x6D, 0xF4, 0x7D, 0x9B,
                0x12A, 0x9C, 0x116, 0xA6, 0xB0, 0x2C, 0x10C, 0x11E, 0x150, 0xD6,
                0x129, 0x10B, 0x132, 0x134, 0xDF, 0x106, 0x107, 0x13C, 0x7B,
                0x20, 0x4F, 0x97, 0xBC, 0x102, 0x13D, 0x44, 0xF7, 0x117, 0xD4,
                0x12D, 0xF0, 0xF1, 0xF2, 0x13B, 0x165, 0xD2, 0x153, 0x90, 0x167,
                0xCC, 0xCA, 0x168, 0x9A, 0xEE, 0xEF, 0x13A, 0x88, 0x69, 0x82,
                0xC0, 0xC1, 0xD, 0x13E, 0x110, 0xCE, 0x131, 0x13F, 0x7C, 0xFD,
                0x27, 0x50, 0x121, 0x23, 0x9D, 0x64, 0x31, 0x62, 0xC4, 0xEA,
                0x138, 0x16B, 0x164, 0x100, 0x42, 0x32, 0x57, 0x7E, 0xE2, 0x118,
                0xB1, 0x89, 0xD9, 0x158, 0xBD, 0xE8, 0x10D, 0x10E, 0x5B, 0xA3,
                0x71, 0x84, 0xB9, 0x38, 0x16, 0x1A, 0x6, 0x34, 0x75, 0x4B, 0x47,
                0xA7, 0x93, 0x5F, 0x2, 0xB5, 0xE9, 0x91, 0x3B, 0xA1, 0x9F, 0x66,
                0xAB, 0x3E, 0xB, 0x1D, 0x8A, 0x101, 0x14, 0x12, 0xC, 0xCF, 0xF8,
                0x159, 0x11D, 0x14F, 0x11A, 0x14C, 0xE5, 0x157, 0x112, 0x152,
                0x12B, 0x137, 0xEB, 0xC8, 0xAA, 0xD5, 0xD0, 0xE6, 0xFC, 0xD8,
                0xF5, 0xB3, 0x25, 0x11, 0xD1, 0x59, 0x162, 0xDA, 0x142, 0x2A,
                0xDC, 0xE4, 0x145, 0x155, 0x2D, 0x139, 0x163, 0x45, 0xEC, 0x7A,
                0x54, 0x149, 0x21, 0x105, 0xBF, 0x8B, 0xDE, 0xCD, 0x154, 0x6B,
                0x2E, 0x8D, 0x55, 0xC5, 0x2B, 0x123, 0xDB, 0xED, 0xFE, 0x11F,
                0x151, 0x80, 0x15A, 0x111, 0xAE, 0x81, 0x8F, 0xA0, 0x104, 0x127,
                0x12F, 0x124, 0x13, 0x12C, 0xC9, 0x10F, 0x28, 0xE3, 0x126, 0xAD,
                0xC7, 0xE, 0x143, 0xFF, 0x5D, 0xA5, 0x73, 0x86, 0xBB, 0x3A,
                0x18, 0x1C, 0x8, 0x36, 0x77, 0x4D, 0x49, 0xA9, 0x95, 0x61, 0x4,
                0xB7, 0xC2, 0x11B, 0x14D, 0xE1, 0x87, 0x3C, 0xD7, 0x11C, 0x14E,
                0x130, 0xC6, 0x12E, 0x22, 0x96, 0xB8, 0x8C, 0x5C, 0xA4, 0x72,
                0x85, 0xBA, 0x39, 0x17, 0x1B, 0x7, 0x35, 0x76, 0x4C, 0x48, 0xA8,
                0x94, 0x60, 0x3, 0xB6, 0x41, 0x98, 0x119, 0x14B, 0x58, 0xFA,
                0x2F, 0xBE, 0x4E, 0x30, 0x133, 0x156, 0x78, 0xCB, 0xDD, 0x63,
                0x10, 0x16A, 0x74, 0x19, 0x4A, 0x16C, 0xAF, 0x141, 0x8E, 0x115,
                0x1E, 0xFB, 0x189, 0x52, 0x148, 0x144, 0xA, 0x43, 0x24 };

            public Item()
            {
                itemBytes = new byte[] { 0, 0, 0, 0, 0, 0, 0 };
            }

            public Item(byte[] itemBytes)
            {
                this.itemBytes = itemBytes;
            }

            /// <summary>
            /// Item index
            /// </summary>
            public short ItemIndex
            {
                get
                {
                    return BitConverter.ToInt16(itemBytes, 0x1);
                }
                set
                {
                    itemBytes[0x1] = (byte)(value & 0xFF);
                    itemBytes[0x2] = (byte)((value >> 8) & 0xFF);
                }
            }

            /// <summary>
            /// Forge level / Remaning uses
            /// </summary>
            public byte Uses
            {
                get
                {
                    return itemBytes[0x4];
                }
                set
                {
                    itemBytes[0x4] = value;
                }
            }

            /// <summary>
            /// Quantity
            /// </summary>
            public byte Quantity
            {
                get
                {
                    return itemBytes[0x5];
                }
                set
                {
                    itemBytes[0x5] = value;
                }
            }

            /// <summary>
            /// Item name.
            /// </summary>
            public String ItemName
            {
                get
                {
                    return ItemNameList[this.ItemIndex];
                }
            }

            /// <summary>
            /// Return the backed up array.
            /// </summary>
            /// <returns></returns>
            public byte[] ToArray()
            {
                return itemBytes;
            }
        }
        #endregion

        public ConvoyEditor()
        {
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        public ConvoyEditor(string filepath)
        {
            this.Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            loadSave(filepath);
        }

        // Load save file
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            loadSave(openFileDialog.FileName);
        }

        // Load save file
        private void loadSave(string filepath)
        {
            int length = (int)(new FileInfo(filepath).Length);
            byte[] header = new byte[0xC0];
            byte[] decompressed = null;
            int magic;
            bool isValidSave = false;
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                br.Read(header, 0, 0xC0);
                magic = br.ReadInt32();
                if (magic == 0x434F4D50) // "COMP", compressed save
                {
                    byte[] compressed = new byte[length - 0xD0];
                    br.BaseStream.Seek(0xD0, SeekOrigin.Begin);
                    br.Read(compressed, 0x0, length - 0xD0);
                    decompressed = new Huffman8().Decompress(compressed);
                    if (BitConverter.ToInt32(decompressed, 0x0) == 0x494E4445)
                        isValidSave = true;
                }
                else if (magic == 0x494E4445) // "INDE", decompressed save
                {
                    decompressed = new byte[length - 0xC0];
                    br.BaseStream.Seek(0xC0, SeekOrigin.Begin);
                    br.Read(decompressed, 0x0, length - 0xC0);
                    isValidSave = true;
                }
            }
            if (!isValidSave)
            {
                MessageBox.Show("Invalid save file.");
                return;
            }

            save = new byte[header.Length + decompressed.Length];
            Array.Copy(header, 0, save, 0, header.Length);
            Array.Copy(decompressed, 0, save, header.Length, decompressed.Length);

            loadItems();
            for (int i = 0; i < Item.SortedItemList.Length; i++)
                itemNameColumn.Items.Add(Item.ItemNameList[Item.SortedItemList[i]]);
            convoyDataGridView.Rows.Add(MaxItem);
            displayItems();
            enableButtons();
        }

        // Activate buttons after loading.
        private void enableButtons()
        {
            saveButton.Enabled = true;
        }

        // Load item data from save file
        private void loadItems()
        {
            for (int i = 0; i < 28; i++)
            {
                int offset = BitConverter.ToInt32(save, 0xC4 + i * 4);
                if ((offset != 0) &&
                    (BitConverter.ToInt32(save, offset) == Magic))
                {
                    convoyOffset = offset;
                }
            }

            itemCount = BitConverter.ToInt16(save, convoyOffset + 0x5);
            items = new Item[MaxItem];
            for (int i = 0; i < itemCount; i++)
            {
                byte[] itemBytes = new byte[7];
                Array.Copy(save, convoyOffset + 0x7 + i * 7, itemBytes, 0, 7);
                items[i] = new Item(itemBytes);
            }
            for (int i = itemCount; i < MaxItem; i++)
            {
                items[i] = new Item();
            }
        }

        private void grayCell(int rowIndex)
        {
            convoyDataGridView.Rows[rowIndex].Cells[1].ReadOnly = true;
            convoyDataGridView.Rows[rowIndex].Cells[1].Style = grayCellStyle;
            convoyDataGridView.Rows[rowIndex].Cells[2].ReadOnly = true;
            convoyDataGridView.Rows[rowIndex].Cells[2].Style = grayCellStyle;
        }

        private void ungrayCell(int rowIndex)
        {
            convoyDataGridView.Rows[rowIndex].Cells[1].ReadOnly = false;
            convoyDataGridView.Rows[rowIndex].Cells[1].Style =
                usesColumn.DefaultCellStyle;
            convoyDataGridView.Rows[rowIndex].Cells[2].ReadOnly = false;
            convoyDataGridView.Rows[rowIndex].Cells[2].Style =
                quantityColumn.DefaultCellStyle;
        }

        private void displayItems()
        {
            for (int i = 0; i < items.Length; i++)
            {
                convoyDataGridView.Rows[i].Cells[0].Value = items[i].ItemName;
                convoyDataGridView.Rows[i].Cells[1].Value = items[i].Uses;
                convoyDataGridView.Rows[i].Cells[2].Value = items[i].Quantity;
                if (items[i].ItemIndex == 0)
                    grayCell(i);
            }
            dataLoaded = true;
        }

        private uint getChecksum(byte[] data) // It's just CRC32.
        {
            uint checksum = 0xFFFFFFFF;
            uint length = (uint)data.Length;
            uint[] table = { 0x00000000, 0x77073096, 0xee0e612c, 0x990951ba, 0x076dc419, 0x706af48f, 0xe963a535, 0x9e6495a3, 0x0edb8832, 0x79dcb8a4, 0xe0d5e91e, 0x97d2d988, 0x09b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91, 0x1db71064, 0x6ab020f2, 0xf3b97148, 0x84be41de, 0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7, 0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec, 0x14015c4f, 0x63066cd9, 0xfa0f3d63, 0x8d080df5, 0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172, 0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b, 0x35b5a8fa, 0x42b2986c, 0xdbbbc9d6, 0xacbcf940, 0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59, 0x26d930ac, 0x51de003a, 0xc8d75180, 0xbfd06116, 0x21b4f4b5, 0x56b3c423, 0xcfba9599, 0xb8bda50f, 0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924, 0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d, 0x76dc4190, 0x01db7106, 0x98d220bc, 0xefd5102a, 0x71b18589, 0x06b6b51f, 0x9fbfe4a5, 0xe8b8d433, 0x7807c9a2, 0x0f00f934, 0x9609a88e, 0xe10e9818, 0x7f6a0dbb, 0x086d3d2d, 0x91646c97, 0xe6635c01, 0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e, 0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457, 0x65b0d9c6, 0x12b7e950, 0x8bbeb8ea, 0xfcb9887c, 0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65, 0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2, 0x4adfa541, 0x3dd895d7, 0xa4d1c46d, 0xd3d6f4fb, 0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0, 0x44042d73, 0x33031de5, 0xaa0a4c5f, 0xdd0d7cc9, 0x5005713c, 0x270241aa, 0xbe0b1010, 0xc90c2086, 0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f, 0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4, 0x59b33d17, 0x2eb40d81, 0xb7bd5c3b, 0xc0ba6cad, 0xedb88320, 0x9abfb3b6, 0x03b6e20c, 0x74b1d29a, 0xead54739, 0x9dd277af, 0x04db2615, 0x73dc1683, 0xe3630b12, 0x94643b84, 0x0d6d6a3e, 0x7a6a5aa8, 0xe40ecf0b, 0x9309ff9d, 0x0a00ae27, 0x7d079eb1, 0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe, 0xf762575d, 0x806567cb, 0x196c3671, 0x6e6b06e7, 0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc, 0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5, 0xd6d6a3e8, 0xa1d1937e, 0x38d8c2c4, 0x4fdff252, 0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b, 0xd80d2bda, 0xaf0a1b4c, 0x36034af6, 0x41047a60, 0xdf60efc3, 0xa867df55, 0x316e8eef, 0x4669be79, 0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236, 0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f, 0xc5ba3bbe, 0xb2bd0b28, 0x2bb45a92, 0x5cb36a04, 0xc2d7ffa7, 0xb5d0cf31, 0x2cd99e8b, 0x5bdeae1d, 0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x026d930a, 0x9c0906a9, 0xeb0e363f, 0x72076785, 0x05005713, 0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0x0cb61b38, 0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0x0bdbdf21, 0x86d3d2d4, 0xf1d4e242, 0x68ddb3f8, 0x1fda836e, 0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777, 0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c, 0x8f659eff, 0xf862ae69, 0x616bffd3, 0x166ccf45, 0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2, 0xa7672661, 0xd06016f7, 0x4969474d, 0x3e6e77db, 0xaed16a4a, 0xd9d65adc, 0x40df0b66, 0x37d83bf0, 0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9, 0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6, 0xbad03605, 0xcdd70693, 0x54de5729, 0x23d967bf, 0xb3667a2e, 0xc4614ab8, 0x5d681b02, 0x2a6f2b94, 0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d };
            if (length > 0)
            {
                int offset = -1;
                if (length % 2 == 1)
                {
                    offset++;
                    checksum = table[(byte)(data[offset] ^ (checksum & 0xFF))] ^ (checksum >> 8);
                }
                uint v12;
                for (uint i = length >> 1; i > 0; checksum = table[(byte)(data[offset] ^ (v12 & 0xFF))] ^ (v12 >> 8))
                {
                    i--;
                    int v10 = (byte)(data[offset + 1] ^ (checksum & 0xFF));
                    offset += 2;
                    v12 = table[v10] ^ (checksum >> 8);
                }
            }
            return ~checksum;
        }

        // Show a dropdown list when clicking to item column
        private void convoyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            ComboBox cb = (ComboBox)convoyDataGridView.EditingControl;
            if (cb != null) cb.DroppedDown = true;
        }

        // Commit a change right after choosing an item
        private void convoyDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if ((convoyDataGridView.IsCurrentCellDirty) &&
                (convoyDataGridView.CurrentCell.ColumnIndex == 0))
            {
                convoyDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Change cells after choosing an items
        private void convoyDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataLoaded) return;
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = convoyDataGridView.Rows[e.RowIndex];
                if ((string)row.Cells[0].Value != Item.ItemNameList[0])
                {
                    int itemIndex = Array.IndexOf(Item.ItemNameList, row.Cells[0].Value);
                    row.Cells[1].Value = Item.BaseUses[itemIndex];
                    row.Cells[2].Value = 1;
                    ungrayCell(e.RowIndex);
                }
                else
                {
                    row.Cells[1].Value = row.Cells[2].Value = 0;
                    grayCell(e.RowIndex);
                }
            }
        }

        // Validate input number
        private void convoyDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dataLoaded) return;
            if ((e.ColumnIndex == 1) || (e.ColumnIndex == 2))
            {
                byte value;
                bool isValidByte = Byte.TryParse(e.FormattedValue.ToString(), out value);
                if (isValidByte)
                {
                    convoyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = null;
                }
                else
                {
                    convoyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText =
                        "Invalid number.";
                    convoyDataGridView.CancelEdit();
                }
            }
        }

        // Save item data to the main save
        private void saveItems()
        {
            byte[] itemBytes;
            short editedItemCount = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                for (int i = 0; i < MaxItem; i++)
                {
                    int itemIndex = Array.IndexOf(Item.ItemNameList,
                        convoyDataGridView.Rows[i].Cells[0].Value.ToString());
                    if (itemIndex != 0)
                    {
                        items[i].ItemIndex = (short)itemIndex;
                        byte value;
                        bool isValid;
                        isValid = Byte.TryParse(convoyDataGridView.Rows[i].Cells[1].Value.ToString(),
                            out value);
                        items[i].Uses = value;
                        isValid = Byte.TryParse(convoyDataGridView.Rows[i].Cells[2].Value.ToString(),
                            out value);
                        items[i].Quantity = value;
                        ms.Write(items[i].ToArray(), 0x0, 7);
                        editedItemCount++;
                    }
                }
                itemBytes = ms.ToArray();
            }

            // Reconstruct the save file with new data
            using (MemoryStream ms = new MemoryStream())
            {
                fixOffsets(convoyOffset, itemBytes.Length - itemCount * 7);
                ms.Write(save, 0x0, convoyOffset);
                ms.Write(BitConverter.GetBytes(Magic), 0x0, 4);
                ms.WriteByte(0x0);
                ms.Write(BitConverter.GetBytes(editedItemCount), 0x0, 2);
                ms.Write(itemBytes, 0x0, itemBytes.Length);
                int remainingOffset = (convoyOffset) + 7 * (itemCount + 1);
                ms.Write(save, remainingOffset, save.Length - remainingOffset);
                save = ms.ToArray();
            }
        }

        // Fix offsets
        private void fixOffsets(int offset, int change)
        {
            for (int i = 0; i < 28; i++)
            {
                int tempOffset = BitConverter.ToInt32(save, 0xC4 + i * 4);
                if (tempOffset > offset)
                {
                    Array.Copy(BitConverter.GetBytes(tempOffset + change), 0,
                        save, 0xC4 + i * 4, 4);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            saveItems();

            // Compress
            byte[] decompressed = new byte[save.Length - 0xC0];
            Array.Copy(save, 0xC0, decompressed, 0x0, save.Length - 0xC0);
            byte[] compressed = new Huffman8().Compress(decompressed);

            // Write
            using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(save, 0x0, 0xC0);
                bw.Write(0x434F4D50); // "COMP"
                bw.Write(0x00000002); // Huffman-8 compression
                bw.Write(save.Length - 0xC0);
                bw.Write(getChecksum(save));
                bw.Write(compressed);
            }
        }
    }
}
