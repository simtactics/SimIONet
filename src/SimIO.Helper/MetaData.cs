/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace SimIO.Data
{
	public enum NeighborhoodSlots
	{
		LotsIntern = 0,
		Lots = 1,
		FamiliesIntern = 2,
		Families = 3,
		SimsIntern = 4,
		Sims = 5
	}
	/// <summary>
	/// Determins the concrete Type of an Overlay Item (texture or mesh overlay)
	/// </summary>
	public enum TextureOverlayTypes : uint
	{
		Beard = 0x00,
		EyeBrow = 0x01,
		Lipstick = 0x02,
        Eye = 0x03,
		Mask = 0x04,
		Glasses = 0x05,
		Blush = 0x06,
        EyeShadow = 0x07
	}
	
	/// <summary>
	/// Ages used for Property Sets (Character Data, Skins)
	/// </summary>
	public enum Ages:uint
	{
		Baby = 0x20,
		Toddler = 0x01,
		Child = 0x02,
		Teen = 0x04,
		Adult = 0x08,
		Elder = 0x10,
		YoungAdult = 0x40
	}

	/// <summary>
	/// Categories used for Property Sets (Skins) (Updated by Theo
	/// </summary>
    [Flags]
    public enum SkinCategories:uint
    {
        Casual1 = 0x01,
        Casual2 = 0x02,
        Casual3 = 0x04,
        Everyday = Casual1 | Casual2 | Casual3,
        Swimmwear = 0x08,
        Pj = 0x10,
        Formal = 0x20,
        Undies = 0x40,
        Skin = 0x80,
        Pregnant = 0x100,
        Activewear = 0x200,
        TryOn = 0x400,
        NakedOverlay = 0x800,
        Outerwear = 0x1000
    }

	/// <summary>
	/// 
	/// </summary>
	public enum Majors:uint 
	{
		Unset = 0,
		Unknown = 0xffffffff,
		Art = 0x2e9cf007,
		Biology = 0x4e9cf02b,
		Drama = 0x4e9cf04d,
		Economics = 0xEe9cf044,
		History = 0x2e9cf074,
		Literature = 0xce9cf085,
		Mathematics = 0xee9cf08d,
		Philosophy = 0x2e9cf057,
		Physics = 0xae9cf063,
		PoliticalScience = 0x4e9cf06d,
		Psychology = 0xCE9CF07C,
		Undeclared = 0x8e97bf1d
	}

	/// <summary>
	/// Room Sort Flag
	/// </summary>
	public enum ObjRoomSortBits:byte
	{
		Kitchen = 0x00,
		Bedroom = 0x01,
		Bathroom = 0x02,
		LivingRoom = 0x03,
		Outside = 0x04,
		DiningRoom = 0x05,
		Misc = 0x06,
		Study = 0x07,
		Kids = 0x08
	}

	/// <summary>
	/// Function Sort Flag 
	/// </summary>
	public enum ObjFunctionSortBits:byte
	{
		Seating = 0x00,
		Surfaces = 0x01,
		Appliances = 0x02,
		Electronics = 0x03,
		Plumbing = 0x04,
		Decorative = 0x05,
		General = 0x06,
		Lighting = 0x07,
		Hobbies = 0x08,
		AspirationRewards = 0x0a,
		CareerRewards = 0x0b
	}

	/// <summary>
	/// Function for xml Based Objects
	/// </summary>	
	public enum XObjFunctionSubSort:uint
	{
		Roof = 0x0100,

		FloorBrick = 0x0201,
		FloorCarpet = 0x0202,
		FloorLino = 0x0204,
		FloorPoured = 0x0208,
		FloorStone = 0x0210,
		FloorTile = 0x0220,
		FloorWood = 0x0240,
		FloorOther = 0x0200,

		FenceRail = 0x0400,
		FenceHalfwall = 0x0401,

		WallBrick = 0x0501,
		WallMasonry = 0x0502,
		WallPaint = 0x0504,
		WallPaneling = 0x0508,
		WallPoured = 0x0510,
		WallSiding = 0x0520,
		WallTile = 0x0540,
		WallWallpaper = 0x0580,
		WallOther = 0x0500,

		Terrain = 0x0600,

		HoodLandmark = 0x0701,
		HoodFlora = 0x0702,
		HoodEffects = 0x0703,
		HoodMisc = 0x0704,
		HoodStone = 0x0705,
		HoodOther = 0x0700
	}

	/// <summary>
	/// Function Sort Flag 
	/// </summary>
	/// <remarks>the higher byte contains the <see cref="ObjFunctionSortBits"/>, the lower one the actual SubSort</remarks>
	public enum ObjFunctionSubSort:uint
	{
		SeatingDiningroomChair = 0x101,
		SeatingLivingroomChair = 0x102,
		SeatingSofas = 0x104,
		SeatingBeds = 0x108,
		SeatingRecreation = 0x110,
		SeatingUnknownA = 0x120,
		SeatingUnknownB = 0x140,
		SeatingMisc = 0x180,

		SurfacesCounter = 0x201,
		SurfacesTable = 0x202,
		SurfacesEndTable = 0x204,
		SurfacesDesks = 0x208,
		SurfacesCoffeetable = 0x210,
		SurfacesBusiness = 0x220,
		SurfacesUnknownB = 0x240,
		SurfacesMisc = 0x280,

		DecorativeWall = 0x2001,
		DecorativeSculpture = 0x2002,
		DecorativeRugs = 0x2004,
		DecorativePlants = 0x2008,
		DecorativeMirror = 0x2010,
		DecorativeCurtain = 0x2020,
		DecorativeUnknownB = 0x2040,
		DecorativeMisc = 0x2080,

		PlumbingToilet = 0x1001,
		PlumbingShower = 0x1002,
		PlumbingSink = 0x1004,
		PlumbingHotTub = 0x1008,
		PlumbingUnknownA = 0x1010,
		PlumbingUnknownB = 0x1020,
		PlumbingUnknownC = 0x1040,
		PlumbingMisc = 0x1080,

		AppliancesCooking = 0x401,
		AppliancesRefrigerator = 0x402,
		AppliancesSmall = 0x404,
		AppliancesLarge = 0x408,
		AppliancesUnknownA = 0x410,
		AppliancesUnknownB = 0x420,
		AppliancesUnknownC = 0x440,
		AppliancesMisc = 0x480,

		ElectronicsEntertainment = 0x801,
		ElectronicsTvAndComputer = 0x802,
		ElectronicsAudio = 0x804,
		ElectronicsSmall = 0x808,
		ElectronicsUnknownA = 0x810,
		ElectronicsUnknownB = 0x820,
		ElectronicsUnknownC = 0x840,
		ElectronicsMisc = 0x880,
		
		LightingTableLamp = 0x8001,
		LightingFloorLamp = 0x8002,
		LightingWallLamp = 0x8004,
		LightingCeilingLamp = 0x8008,
		LightingOutdoor = 0x8010,
		LightingUnknownA = 0x8020,
		LightingUnknownB = 0x8040,
		LightingMisc = 0x8080,
		
		HobbiesCreative = 0x10001,
		HobbiesKnowledge = 0x10002,
		HobbiesExcerising = 0x10004,
		HobbiesRecreation = 0x10008,
		HobbiesUnknownA = 0x10010,
		HobbiesUnknownB = 0x10020,
		HobbiesUnknownC = 0x10040,
		HobbiesMisc = 0x10080,

		GeneralUnknownA = 0x4001,
		GeneralDresser = 0x4002,
		GeneralUnknownB = 0x4004,
		GeneralParty = 0x4008,
		GeneralChild = 0x4010,
		GeneralCar = 0x4020,
		GeneralPets = 0x4040,
		GeneralMisc = 0x4080,
				
		AspirationRewardsUnknownA = 0x40001,
		AspirationRewardsUnknownB = 0x40002,
		AspirationRewardsUnknownC = 0x40004,
		AspirationRewardsUnknownD = 0x40008,
		AspirationRewardsUnknownE = 0x40010,
		AspirationRewardsUnknownF = 0x40020,
		AspirationRewardsUnknownG = 0x40040,
		AspirationRewardsUnknownH = 0x40080,

		CareerRewardsUnknownA = 0x80001,
		CareerRewardsUnknownB = 0x80002,
		CareerRewardsUnknownC = 0x80004,
		CareerRewardsUnknownD = 0x80008,
		CareerRewardsUnknownE = 0x80010,
		CareerRewardsUnknownF = 0x80020,
		CareerRewardsUnknownG = 0x80040,
		CareerRewardsUnknownH = 0x80080
	}

	/// <summary>
	/// Enumerates known Object Types
	/// </summary>
	public enum ObjectTypes:ushort 
	{
		Unknown = 0x0000,
		Person = 0x0002,
		Normal = 0x0004,
		ArchitecturalSupport = 0x0005,
		SimType = 0x0007,
		Door = 0x0008,
		Window = 0x0009,
		Stairs = 0x000A,
		ModularStairs = 0x000B,
		ModularStairsPortal = 0x000C,
		Vehicle = 0x000D,
		Outfit = 0x000E,
		Memory = 0x000F,
		Template = 0x0010,
		Tiles = 0x0013
	}

	/// <summary>
	/// Hold Constants, Enumerations and other Metadata
	/// </summary>
    public class MetaData
    {
        /// <summary>
        /// Color of a Sim that is either Unlinked or does not have Character Data
        /// </summary>
        public static Color SpecialSimColor = Color.FromArgb(0xD0, Color.Black);

        /// <summary>
        /// Color of a Sim that is unlinked
        /// </summary>
        public static Color UnlinkedSim = Color.FromArgb(0xEF, Color.SteelBlue);

        /// <summary>
        /// Color of a NPC Sim
        /// </summary>
        public static Color NpcSim = Color.FromArgb(0xEF, Color.YellowGreen);

        /// <summary>
        /// Color of a Sim that has no Character Data
        /// </summary>
        public static Color InactiveSim = Color.FromArgb(0xEF, Color.LightCoral);

        #region Constants

        /// <summary>
        /// Group for Costum Content
        /// </summary>
        public const uint CustomGroup = 0x1C050000;

        /// <summary>
        /// Group for Global Content
        /// </summary>
        public const uint GlobalGroup = 0x1C0532FA;

        /// <summary>
        /// Group for Local Content
        /// </summary>
        public const uint LocalGroup = 0xffffffff;

        /// <summary>
        /// A Directory file will have this Type in the fileindex.
        /// </summary>
        public const uint DirectoryFile = 0xE86B1EEF; //0xEF1E6BE8;

        /// <summary>
        /// Stores the relationship Value for a Sim
        /// </summary>
        public const uint RelationFile = 0xCC364C2A;

        /// <summary>
        /// File Containing Strings
        /// </summary>
        public const uint StringFile = 0x53545223;

        /// <summary>
        /// File Containing Pie Strings
        /// </summary>
        public const uint PieStringFile = 0x54544173;

        /// <summary>
        /// File Containing Sim Descriptions
        /// </summary>
        public const uint SimDescriptionFile = 0xAACE2EFB;

        /// <summary>
        /// Files Containing Sim Images
        /// </summary>
        public const uint SimImageFile = 0x856DDBAC;

        /// <summary>
        /// The File containing all Family Ties
        /// </summary>
        public const uint FamilyTiesFile = 0x8C870743;

        /// <summary>
        /// File containing BHAV Informations
        /// </summary>
        public const uint BhavFile = 0x42484156;

        /// <summary>
        /// File containng Global Data
        /// </summary>
        public const uint GlobFile = 0x474C4F42;

        /// <summary>
        /// File Containing Object Data
        /// </summary>
        public const uint ObjdFile = 0x4F424A44;

        /// <summary>
        /// File Containing Catalog Strings
        /// </summary>
        public const uint CtssFile = 0x43545353;

        /// <summary>
        /// File Containing Name Maps
        /// </summary>
        public const uint NameMap = 0x4E6D6150;

        /// <summary>
        /// Neighborhood/Memory File Typesss
        /// </summary>
        public const uint Memories = 0x4E474248;


        /// <summary>
        /// Sim DNA
        /// </summary>
        public const uint Sdna = 0xEBFEE33F;

        /// <summary>
        /// Signature identifying a compressed PackedFile
        /// </summary>
        public const ushort CompressSignature = 0xFB10;

        public const uint Gzps = 0xEBCF3E27;
        public const uint Xwnt = 0xED7D7B4D;
        public const uint RefFile = 0xAC506764;
        public const uint Idno = 0xAC8A7A2E;
        public const uint Hous = 0x484F5553;
        public const uint Slot = 0x534C4F54;

        public const uint Gmnd = 0x7BA3838C;
        public const uint Txmt = 0x49596978;
        public const uint Txtr = 0x1C4A276C;
        public const uint Lifo = 0xED534136;
        public const uint Anim = 0xFB00791E;
        public const uint Shpe = 0xFC6EB1F7;
        public const uint Cres = 0xE519C933;
        public const uint Gmdc = 0xAC4F8687;
        public const uint Ldir = 0xC9C81B9B;
        public const uint Lamb = 0xC9C81BA3;
        public const uint Lpnt = 0xC9C81BA9;
        public const uint Lspt = 0xC9C81BAD;

        public const uint Mmat = 0x4C697E5A;
        public const uint Xobj = 0xCCA8E925;
        public const uint Xrof = 0xACA8EA06;
        public const uint Xflr = 0x4DCADB7E;
        public const uint Xfnc = 0x2CB230B8;
        public const uint Xngb = 0x6D619378;

        public const uint Glua = 0x9012468A;
        public const uint Olua = 0x9012468B;

        #endregion

        #region Enums

        /// <summary>
        /// Type of school a Sim attends
        /// </summary>
        public enum SchoolTypes : uint
        {
            Unknown = 0x00000000,
            PublicSchool = 0xD06788B5,
            PrivateSchool = 0xCC8F4C11
        }

        /// <summary>
        /// Available Grades
        /// </summary>
        public enum Grades : ushort
        {
            Unknown = 0x00,
            F = 0x01,
            DMinus = 0x02,
            D = 0x03,
            DPlus = 0x04,
            CMinus = 0x05,
            C = 0x06,
            CPlus = 0x07,
            BMinus = 0x08,
            B = 0x09,
            BPlus = 0x0A,
            AMinus = 0x0B,
            A = 0x0C,
            APlus = 0x0D
        }



        /// <summary>
        /// Enumerates known Languages
        /// </summary>
        public enum Languages : byte
        {
            Unknown = 0x00,
            English = 0x01,
            EnglishUk = 0x02,
            French = 0x03,
            German = 0x04,
            Italian = 0x05,
            Spanish = 0x06,
            Dutch = 0x07,
            Danish = 0x08,
            Swedish = 0x09,
            Norwegian = 0x0a,
            Finnish = 0x0b,
            Hebrew = 0x0c,
            Russian = 0x0d,
            Portuguese = 0x0e,
            Japanese = 0x0f,
            Polish = 0x10,
            SimplifiedChinese = 0x11,
            TraditionalChinese = 0x12,
            Thai = 0x13,
            Korean = 0x14,
            Czech = 0x1a,
            Brazilian = 0x23
        }

        /// <summary>
        /// Enumerates available Datatypes
        /// </summary>
        public enum DataTypes : uint
        {
            DtUInteger = 0xEB61E4F7,
            DtString = 0x0B8BEA18,
            DtSingle = 0xABC78708,
            DtBoolean = 0xCBA908E1,
            DtInteger = 0x0C264712
        }

        /// <summary>
        /// Available Format Codes
        /// </summary>
        public enum FormatCode : ushort
        {
            Normal = 0xFFFD
        }

        /// <summary>
        /// Is an Item within the PackedFile Index new Alias(0x20 , "or 0x24 Bytes long"),
        /// </summary>
        public enum IndexTypes : uint
        {
            PtShortFileIndex = 0x01,
            PtLongFileIndex = 0x02
        }

        /// <summary>
        /// Which general apiration does a Sim have
        /// </summary>
        public enum AspirationTypes : ushort
        {
            Nothing = 0x00,
            Romance = 0x01,
            Family = 0x02,
            Fortune = 0x04,
            Reputation = 0x10,
            Knowledge = 0x20,
            Growup = 0x40,
            Fun = 0x80,
            Chees = 0x100
        }

        /// <summary>
        /// Relationships a Sim can have
        /// </summary>
        public enum RelationshipStateBits : byte
        {
            Crush = 0x00,
            Love = 0x01,
            Engaged = 0x02,
            Married = 0x03,
            Friends = 0x04,
            Buddies = 0x05,
            Steady = 0x06,
            Enemy = 0x07,
            Family = 0x0E,
            Known = 0x0F
        }

        /// <summary>
        /// UIFlags2 - more relationship states
        /// </summary>
        public enum UiFlags2Names : byte
        {
            BestFriendForever = 0x00
        }


        /// <summary>
        /// Available Zodia Signes
        /// </summary>
        public enum ZodiacSignes : ushort
        {
            Aries = 0x01,		 //de: Widder
            Taurus = 0x02,
            Gemini = 0x03,
            Cancer = 0x04,
            Leo = 0x05,
            Virgo = 0x06,		 //de: Jungfrau
            Libra = 0x07,		 //de: Waage
            Scorpio = 0x08,
            Sagittarius = 0x09,  //de: Sch�tze
            Capricorn = 0x0A,	 //de: Steinbock
            Aquarius = 0x0B,
            Pisces = 0x0C		 //de: Fische
        }

        /// <summary>
        /// Known Types for Family ties
        /// </summary>
        public enum FamilyTieTypes : uint
        {
            MyMotherIs = 0x00,
            MyFatherIs = 0x01,
            ImMarriedTo = 0x02,
            MySiblingIs = 0x03,
            MyChildIs = 0x04
        }

        /// <summary>
        /// Detailed Relationships between Sims
        /// </summary>
        public enum RelationshipTypes : uint
        {
            UnsetUnknown = 0x00,
            Parent = 0x01,
            Child = 0x02,
            Sibling = 0x03,
            Gradparent = 0x04,
            Grandchild = 0x05,
            NiceNephew = 0x07,
            Aunt = 0x06,
            Cousin = 0x08,
            Spouses = 0x09
        }

        /// <summary>
        /// How old (in Life Sections) is the Sim
        /// </summary>
        public enum LifeSections : ushort
        {
            Unknown = 0x00,
            Baby = 0x01,
            Toddler = 0x02,
            Child = 0x03,
            Teen = 0x10,
            Adult = 0x13,
            Elder = 0x33,
            YoungAdult = 0x40
        }

        /// <summary>
        /// Gender of a Sim
        /// </summary>
        public enum Gender : ushort
        {
            Male = 0x00,
            Female = 0x01
        }

        /// <summary>
        /// The Jobs known by SimPE
        /// </summary>
        /// <remarks>Use finder dock object search for JobData*</remarks>
        public enum Careers : uint
        {
            Unknown = 0xFFFFFFFF,
            Unemployed = 0x00000000,
            Military = 0x6C9EBD32,
            Politics = 0x2C945B14,
            Science = 0x0C9EBD47,
            Medical = 0x0C7761FD,
            Athletic = 0x2C89E95F,
            Economy = 0x45196555,
            LawEnforcement = 0xAC9EBCE3,
            Culinary = 0xEC9EBD5F,
            Slacker = 0xEC77620B,
            Criminal = 0x6C9EBD0E,
            TeenElderAthletic = 0xAC89E947,
            TeenElderBusiness = 0x4C1E0577,
            TeenElderCriminal = 0xACA07ACD,
            TeenElderCulinary = 0x4CA07B0C,
            TeenElderLawEnforcement = 0x6CA07B39,
            TeenElderMedical = 0xAC89E918,
            TeenElderMilitary = 0xCCA07B66,
            TeenElderPolitics = 0xCCA07B8D,
            TeenElderScience = 0xECA07BB0,
            TeenElderSlacker = 0x6CA07BDC,
            Paranormal = 0x2E6FFF87,
            NaturalScientist = 0xEE70001C,
            ShowBiz = 0xAE6FFFB0,
            Artist = 0x4E6FFFBC,
            Adventurer = 0x3240CBA5,
            Education = 0x72428B30,
            Gamer = 0xF240C306,
            Journalism = 0x7240D944,
            Law = 0x12428B19,
            Music = 0xB2428B0C,
            TeenElderAdventurer = 0xF240D235,
            TeenElderEducation = 0xD243BBEC,
            TeenElderGamer = 0x1240C962,
            TeenElderJournalism = 0x5240E212,
            TeenElderLaw = 0x1243BBDE,
            TeenElderMusic = 0xB243BBD2,
            PetSecurity = 0xD188A400,
            PetService = 0xB188A4C1,
            PetShowBiz = 0xD175CC2D,
            TeenElderConstruction = 0x53E1C30F,
            TeenElderDance = 0xD3E094A5,
            TeenElderEntertainment = 0x53E09494,
            TeenElderIntelligence = 0x93E094C0,
            TeenElderOcenography = 0x13E09443,
            Construction = 0xF3E1C301,
            Dance = 0xD3E09422,
            Entertainment = 0xB3E09417,
            Intelligence = 0x33E0940E,
            Ocenography = 0x73E09404

        }
        #endregion

        #region Arrays

        /// <summary>
        /// all Known SemiGlobal Groups
        /// </summary>
        static SemiGlobalListing _sgl;

        static IEnumerable<SemiGlobalAlias> SemiGlobals{
             get {
                 if (_sgl == null) LoadSemGlobList();
                 return _sgl;
             }
        }
        static void LoadSemGlobList()
        {
            _sgl = new SemiGlobalListing();
            _sgl.Sort();
        }
        public static uint SemiGlobalId(string sgname)
        {
            foreach (var sga in SemiGlobals) if (sga.Name.Trim().ToLowerInvariant().Equals(sgname.Trim().ToLowerInvariant())) return sga.Id;
            return 0;
        }
        public static string SemiGlobalName(uint sgid)
        {
            foreach (var sga in SemiGlobals) if (sga.Id == sgid) return sga.Name;
            return "";
        }



        #endregion

        #region Supporting Methods
        /// <summary>
        /// Returns the Group Number of a SemiGlobal File
        /// </summary>
        /// <param name="name">the nme of the semi global</param>
        /// <returns>The group Vlue of the Global</returns>
        public static Alias FindSemiGlobal(string name)
        {
            name = name.ToLower();
            foreach (Alias a in SemiGlobals)
            {
                if (a.Name.ToLower() == name) return a;
            } //for

            //unknown SemiGlobal
            return new Alias(0xffffffff, name.ToLower());
        }
        #endregion

        #region Map's
        static ArrayList _rcollist;
        static ArrayList _complist;
        static Hashtable _agelist;
        static List<uint> _cachedft;

        public static List<uint> CachedFileTypes
        {
            get
            {
                if (_cachedft == null)
                {
                    _cachedft = new List<uint>();

                    foreach (uint i in RcolList)
                        _cachedft.Add(i);

                    _cachedft.Add(ObjdFile);
                    _cachedft.Add(CtssFile);
                    _cachedft.Add(StringFile);

                    _cachedft.Add(Xflr);
                    _cachedft.Add(Xfnc);
                    _cachedft.Add(Xngb);
                    _cachedft.Add(Xobj);
                    _cachedft.Add(Xrof);
                    _cachedft.Add(Xwnt);
                }
                return _cachedft;
            }
        }

        //Returns a List of all RCOl Compatible File Types
        public static ArrayList RcolList
        {
            get
            {
                if (_rcollist == null)
                {
                    _rcollist = new ArrayList();

                    _rcollist.Add(Gmdc);	//GMDC
                    _rcollist.Add(Txtr);	//TXTR
                    _rcollist.Add(Lifo);	//LIFO
                    _rcollist.Add(Txmt);	//MATD
                    _rcollist.Add(Anim);	//ANIM
                    _rcollist.Add(Gmnd);	//GMND
                    _rcollist.Add(Shpe);	//SHPE
                    _rcollist.Add(Cres);	//CRES
                    _rcollist.Add(Ldir);
                    _rcollist.Add(Lamb);
                    _rcollist.Add(Lspt);
                    _rcollist.Add(Lpnt);
                }

                return _rcollist;
            }
        }

        //Returns a List of File Types that should be compressed
        public static ArrayList CompressionCandidates
        {
            get
            {
                if (_complist == null)
                {
                    _complist = RcolList;

                    _complist.Add(StringFile);
                    _complist.Add((uint)0x0C560F39); //Binary Index
                    _complist.Add(0xAC506764); //3D IDR
                }

                return _complist;
            }
        }

        /// <summary>
        /// translates the Ages from a SDesc to a Property Set age 
        /// </summary>
        public static Ages AgeTranslation(LifeSections age)
        {
            _agelist = new Hashtable();
            if (age == LifeSections.Adult) return Ages.Adult;
            if (age == LifeSections.Baby) return Ages.Baby;
            if (age == LifeSections.Child) return Ages.Child;
            if (age == LifeSections.Elder) return Ages.Elder;
            if (age == LifeSections.Teen) return Ages.Teen;
            if (age == LifeSections.Toddler) return Ages.Toddler;
            return Ages.Adult;

        }
        #endregion
    }
}
