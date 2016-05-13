using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace VideoGames
{
  public class Game : INotifyPropertyChanged
  {
    string _name;
    public string Name 
    {
      get { return _name; } 
      set 
      {
        if (value != _name)
        {
          _name = value;
          FirePropertyChanged("Name");
        }
      }
    }

    string _description;
    public string Description 
    {
      get { return _description; } 
      set 
      {
        if (value !=  _description)
        {
          _description = value;
          FirePropertyChanged("Description");
        }
      }
    }

    decimal _price;
    public decimal Price 
    {
      get { return _price; } 
      set 
      {
        if (value !=  _price)
        {
          _price = value;
          FirePropertyChanged("Price");
        }
      }
    }

    DateTime _releaseDate ;
    public DateTime ReleaseDate 
    {
      get { return _releaseDate; } 
      set 
      {
        if (value !=  _releaseDate)
        {
          _releaseDate = value;
          FirePropertyChanged("ReleaseDate");
        }
      }
    }

    string _imageUrl;
    public string ImageUrl 
    {
      get { return _imageUrl; } 
      set 
      {
        if (value !=  _imageUrl)
        {
          _imageUrl = value;
          FirePropertyChanged("ImageUrl");
        }
      }
    }

    string _priceCurrency;
    public string PriceCurrency 
    {
      get { return _priceCurrency; } 
      set 
      {
        if (value !=  _priceCurrency)
        {
          _priceCurrency = value;
          FirePropertyChanged("PriceCurrency");
        }
      }
    }

    string _genre;
    public string Genre 
    {
      get { return _genre; } 
      set 
      {
        if (value !=  _genre)
        {
          _genre = value;
          FirePropertyChanged("Genre");
        }
      }
    }

    string _publisher;
    public string Publisher 
    {
      get { return _publisher; } 
      set 
      {
        if (value !=  _publisher)
        {
          _publisher = value;
          FirePropertyChanged("Publisher");
        }
      }
    }

    string _developer;
    public string Developer 
    {
      get { return _developer; } 
      set 
      {
        if (value !=  _developer)
        {
          _developer = value;
          FirePropertyChanged("Developer");
        }
      }
    }

    ESRBRating _gameRating;
    public ESRBRating GameRating 
    {
      get { return _gameRating; } 
      set 
      {
        if (value != _gameRating)
        {
          _gameRating = value;
          FirePropertyChanged("GameRating");
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void FirePropertyChanged(string propertyName)
    {
      if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }

  public class ESRBRating
  {
    // Don't allow construction
    private ESRBRating() { }

    static ESRBRating()
    {
      RatingLookup = new Dictionary<string, ESRBRating>();

      Unknown = new ESRBRating() { Name = "", Url = "" };
      RatingLookup[Unknown.Name] = Unknown;
      E = new ESRBRating() { Name = "E (Everyone)", Url = "/images/ESRB_E.gif" };
      RatingLookup[E.Name] = E;
      E10 = new ESRBRating() { Name = "E10 (Everyone 10+)", Url = "/images/ESRB_E10.gif" };
      RatingLookup[E10.Name] = E10;
      T = new ESRBRating() { Name = "T (Teen)", Url = "/images/ESRB_T.gif" };
      RatingLookup[T.Name] = T;
      M = new ESRBRating() { Name = "M (Mature)", Url = "/images/ESRB_M.gif" };
      RatingLookup[M.Name] = M;
      RP = new ESRBRating() { Name = "RP (Rating Pending)", Url = "/images/ESRB_RP_M.gif" };
      RatingLookup[RP.Name] = RP;
    }

    // Properties
    public string Name { get; set; }
    public string Url { get; set; }

    // Override so that it shows the name when shown
    public override string ToString()
    {
      return Name;
    }

    public static readonly ESRBRating Unknown;
    public static readonly ESRBRating E;
    public static readonly ESRBRating E10;
    public static readonly ESRBRating T;
    public static readonly ESRBRating M;
    public static readonly ESRBRating RP;
    protected static Dictionary<string, ESRBRating> RatingLookup;

    public static ESRBRating Lookup(string fullName)
    {
      if (!RatingLookup.ContainsKey(fullName)) return null;
      return RatingLookup[fullName];
    }
  }

  public class GameList : ObservableCollection<Game>
  {
    public GameList() : base()
    {
      Add(new Game() { Name = "Red Dead Redemption™", Description = "At the turn of the twentiethÂ century, when the chaotic badlands began to give way to the expanding reach of government and the spread of the Industrial Age, a former outlaw, John Marston, is sent across the American frontier to help bring the rule of law in Red Dead Redemption.", Price = 59.99m, ReleaseDate = new DateTime(2010, 4, 27), ImageUrl = "http://www.xbox.com/NR/rdonlyres/7400CA92-D767-4B52-81D1-749A44303514/0/boxreddeadredemption.jpg", Genre = "Action", Publisher = "Rockstar San Diego", Developer = "Rockstar San Diego", GameRating = ESRBRating.Lookup("RP (Rating Pending)"),  });
      Add(new Game() { Name = "Final Fantasy™ XIII", Description = "Final Fantasy™ XIII", Price = 0m, ReleaseDate = new DateTime(2010, 3, 9), ImageUrl = "http://www.xbox.com/NR/rdonlyres/90824A15-1BCC-4D6C-A60F-E63C5F51225E/0/boxfinalfantasyxii.jpg", Genre = "RPG", Publisher = "", Developer = "", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Battlefield: Bad Company 2™", Description = "Battlefield Bad Company 2 brings the Battlefield gameplay to the forefront featuring best-in-class vehicular combat with unexpected “Battlefield moments.“ New vehicles like the ATV and a transport helicopter allow for all-new multiplayer tactics in the warzone. With the Frostbite-enabled Destruction 2.0 system you can take entire buildings down, and create your own fire points by blasting holes through cover.", Price = 0m, ReleaseDate = new DateTime(2010, 3, 2), ImageUrl = "http://www.xbox.com/NR/rdonlyres/96A52CC0-4EE9-4226-86E8-2AE8FD5440CB/0/boxbattlefieldbadcompany2.jpg", Genre = "Shooter", Publisher = "DICE", Developer = "DICE", GameRating = ESRBRating.Lookup("RP (Rating Pending)"),  });
      Add(new Game() { Name = "Tom Clancy's Splinter Cell Conviction", Description = "Coming exclusively to Xbox 360Â®, Tom Clancy's Splinter Cell Conviction is the highly anticipated sequel in the multimillion-selling Splinter Cell series and one of the most critically acclaimed Xbox franchises of all time.", Price = 59.99m, ReleaseDate = new DateTime(2010, 2, 23), ImageUrl = "http://www.xbox.com/NR/rdonlyres/156C7B72-229D-44CB-A0CB-B5DA45E9CFA7/0/boxsplintercellconviction.jpg", Genre = "Action", Publisher = "UbiSoft Montreal", Developer = "UbiSoft Montreal", GameRating = ESRBRating.Lookup("RP (Rating Pending)"),  });
      Add(new Game() { Name = "Blur", Description = "Blur is the ultimate racing experience, dropping you into heart-pumping, electrified in-the-pack action with 20 cars targeting the finish line and battling each other as they trade paint.Â Intense power-ups, including the ability to blast other cars out of the way with huge bursts of energy, as well as defensive shields, nitro speed boosts, and landmines create realistic damage and destruction.Â ", Price = 59.99m, ReleaseDate = new DateTime(2010, 2, 15), ImageUrl = "http://www.xbox.com/NR/rdonlyres/31D0476D-08AB-49DB-ABA0-01C434A9C864/0/boxblur.jpg", Genre = "Racing", Publisher = "Bizarre Creations", Developer = "Bizarre Creations", GameRating = ESRBRating.Lookup("RP (Rating Pending)"),  });
      Add(new Game() { Name = "BioShock® 2", Description = "Step back into the unforgettable world of Rapture in BioShockÂ® 2, the next installment in the franchise that has won more than 50 Game of the Year Awards and has sold more than 2.5 million units worldwide. Developed by 2K Marin, 2K Australia, Digital Extremes and 2K China, BioShock 2 features the perfect blend of explosive first person shooter combat, compelling storytelling, and intense multiplayer to form one of 2010's most highly anticipated titles.Â Â Â Â Â Â Â  Â ", Price = 59.99m, ReleaseDate = new DateTime(2010, 2, 9), ImageUrl = "http://www.xbox.com/NR/rdonlyres/E5053383-02CC-43B2-8BE4-A51F53ABCAE1/0/boxbioshock2.jpg", Genre = "Shooter", Publisher = "2K Marin, 2K Australia", Developer = "2K Marin, 2K Australia", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Mass Effect 2™", Description = "Two years afterÂ Commander ShepardÂ repelled invading Reapers bent on the destruction of organic life, a mysterious new enemy has emerged in Mass Effect 2.Â On the fringes of known space, something is silently abducting entire human colonies.Â Now Shepard must work with Cerberus,Â a ruthless organization devoted to human survival at any cost, to stop the most terrifying threat mankind has ever faced.Â To even attempt this perilous mission, Shepard must assemble the galaxy's most elite team of specialists and command the most powerful ship ever built.Â Even then, they say it would beÂ suicide.Â Commander Shepard intends to prove them wrong.", Price = 59.99m, ReleaseDate = new DateTime(2010, 1, 26), ImageUrl = "http://www.xbox.com/NR/rdonlyres/20AC2DC4-B437-4145-AB34-5CDD5D926CFB/0/boxmassEffect2.jpg", Genre = "RPG", Publisher = "BioWare - A Division of EA", Developer = "BioWare - A Division of EA", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Army of Two™: The 40th Day", Description = "Army of Two: The 40th DayÂ has been built from the ground up with a focus on an incredible cooperative experience. The result is a bigger, better, more organic and immersive co-op experience that lets you put your best two-man tactics to use whenever and wherever you want.Â ", Price = 59.99m, ReleaseDate = new DateTime(2010, 1, 12), ImageUrl = "http://www.xbox.com/NR/rdonlyres/0B2C6E79-D82D-498E-97CB-8B0764C5EFDE/0/boxarmyoftwothe40thday.jpg", Genre = "Shooter", Publisher = "EA Montreal", Developer = "EA Montreal", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Dark Void", Description = "Dark Void is a new sci-fi action-adventure game combining an adrenaline-fuelled blend of aerial and on-foot combat set in a parallel universe called “The Void.“ Take on the role of Will, a pilot on a routine air cargo flight dropped into incredible circumstances as he crashes in the Bermuda Triangle leading him to be trapped in the Void. Will soon finds himself swept into a desperate struggle for survival at the head of a group called The Survivors. Trapped in the Void, these resistance fighters are battling to hold off a mysterious alien race that plans to threaten Earth. ", Price = 59.99m, ReleaseDate = new DateTime(2010, 1, 12), ImageUrl = "http://www.xbox.com/NR/rdonlyres/72E237AB-BF70-4311-82A1-EA580EC3A764/0/boxdarkvoid.jpg", Genre = "Action", Publisher = "Capcom", Developer = "Capcom", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Vancouver 2010™ - The Official Video Game of the Olympic Winter Games", Description = "Vancouver 2010™ - The Official Video Game of the Olympic Winter Games", Price = 49.95m, ReleaseDate = new DateTime(2010, 1, 12), ImageUrl = "http://www.xbox.com/NR/rdonlyres/A419675D-5350-448B-852F-4DBB4394DF8A/0/boxvancouver2010.jpg", Genre = "Sports", Publisher = "Eurocom", Developer = "Eurocom", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "Bayonetta", Description = "Bayonetta is a cinematic, stylized action game from the creative mind of renowned game developer Hideki Kamiya (creator of the Devil May Cry series), featuring a stylish and sexy heroine poised to become the next video game icon. In this epic battle, Bayonetta faces off against countless angelic enemies ranging in size from small minions to gigantic behemoths bringing to life a game of one hundred percent pure action.", Price = 59.99m, ReleaseDate = new DateTime(2010, 1, 5), ImageUrl = "http://www.xbox.com/NR/rdonlyres/0EE7D19E-20F9-48CD-96E3-200807E6EC8E/0/boxbayonetta.jpg", Genre = "Action", Publisher = "Platinum Games", Developer = "Platinum Games", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Darksiders", Description = "Deceived by the forces of evil into prematurely bringing about the end of the world, Warâ€”the first Horseman of the Apocalypseâ€”stands accused of breaking the sacred law by inciting a war between Heaven and Hell. In the slaughter that ensued, the demonic forces defeated the heavenly hosts and laid claim to the Earth. Brought before the sacred Charred Council, War is indicted for his crimes and stripped of his powers.Â Dishonored and facing his own death, War is given the opportunity to return to Earth to search for the truth and punish those responsible in Darksiders.", Price = 59.99m, ReleaseDate = new DateTime(2010, 1, 5), ImageUrl = "http://www.xbox.com/NR/rdonlyres/90083632-E177-4D46-9D93-004181D02D23/0/boxdarksiders.jpg", Genre = "Action", Publisher = "Vigil Games", Developer = "Vigil Games", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Divinity II - Ego Draconis", Description = "Many years have passed since the darkness of Damianâ€™s armies was repelled and he was banished from the world of Rivellon. While men enjoy their first years of real peace, Damian breaks free from his bonds and returns to take vengeance. And with him come the dragons.Â In Divinity II - Ego Draconis, you are the only one who stands in the way of evil. In this new installment to the award winning Divinity series, face your destiny and become one of the worldâ€™s most mysterious and powerful beings, a Dragon Knight. Fight as both, human and dragon, use your powerful battle tower as a base of operations, create creatures to support you in battle, and delve deep into a story that unfolds depending on your choices. Your decisions determine the fate of Rivellon.", Price = 0m, ReleaseDate = new DateTime(2010, 1, 5), ImageUrl = "http://www.xbox.com/NR/rdonlyres/2A6968D6-77B9-49BF-8D93-5C1D90BC802A/0/boxdivinityii.jpg", Genre = "RPG", Publisher = "Larian Studios ", Developer = "Larian Studios ", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Guitar Hero® Van Halen®", Description = "Guitar HeroÂ® returns with another band-focused title, Guitar HeroÂ® Van HalenÂ®! The game features 25 classic Van Halen tracks, three signature Eddie Van Halen guitar solos, and 19 hand-picked guest acts. Rock around the globe, from a small club in Los Angeles to arenas around the world, including the iconic “S-stage“ from the Rock and Roll Hall of Famers' 2007 world tour.", Price = 59.99m, ReleaseDate = new DateTime(2009, 12, 22), ImageUrl = "http://www.xbox.com/NR/rdonlyres/01A8617B-4DA7-48CC-8354-F2BD41C7F30B/0/boxguitarherovanhalen.jpg", Genre = "Music", Publisher = "", Developer = "", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Alien Breed™ Episode 1", Description = "Alien Breed Evolution (Episode 1) marks the rebirth of a gaming legend that has laid dormant for years. While the core gameplay remains intact, the technology, online component, and production values have improved immeasurably for your pleasure. The first episode of three has you battling alone or partnering up against the “breed,“ offline or online over five action-packed single-player levels and three multiplayer levels. Including bar-raising visuals and immersive gameplay, Alien Breed Evolution (Episode 1) is the definitive must-have action horror title you've been waiting for!", Price = 800m, ReleaseDate = new DateTime(2009, 12, 16), ImageUrl = "http://www.xbox.com/NR/rdonlyres/16ED0ECA-2736-400D-9D76-A9F842EE33E4/0/boxalienbreedevoep1.jpg", Genre = "Action", Publisher = "Team17 Software Ltd", Developer = "Team17 Software Ltd", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Puzzlegeddon™", Description = "Set in an array of galaxies, Puzzlegeddon features a clever mix of puzzle, action, and strategy in a fast-paced and exciting game! Compete for the top spot on the planet by creating multiple combos for the quickest way to gather enough resources to blast your enemies out of this world. Or, if you find yourself on the perilous poisonous planet, solve brainteasers to survive for as long as possible and rack up a high score.Â Battle up to five players on Xbox LIVEÂ® in a variety of galaxies in this stylish and quirky puzzle brawler.", Price = 800m, ReleaseDate = new DateTime(2009, 12, 16), ImageUrl = "http://www.xbox.com/NR/rdonlyres/EF97B81D-8DD2-4920-A2BA-67DC1A0128E2/0/boxpuzzlegeddon.jpg", Genre = "Puzzle and Word", Publisher = "Pieces Interactive", Developer = "Pieces Interactive", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "QIX++", Description = "Inheriting the style of the renowned arcade title, QIX++ allows you to take up the fight again in a variety of different ways. With customized weapon improvements, a technique-based scoring system, and events triggered by opening Item Containers, the evolution of the series has truly come a long way. ", Price = 800m, ReleaseDate = new DateTime(2009, 12, 9), ImageUrl = "http://www.xbox.com/NR/rdonlyres/A80BA4F9-6F61-42F6-9CC0-A29912600D55/0/boxQix.jpg", Genre = "Action", Publisher = "Taito Corporation", Developer = "Taito Corporation", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "The Saboteur™", Description = "Welcome to Nazi-occupied Paris, a unique open world where you are The Saboteur. Play as Sean Devlin, a street-tough Irish racing mechanic seeking personal redemption on a Nazi officer that has taken everything away from him. Now, it's time for paybackâ€”with the help of the French Resistance, British intelligence, an arsenal of weaponry, and your own street smarts and brawn, you must exact revenge on those who aimed to destroy your life.Â Motivated by retribution and armed with tactics of sabotage, blow up zeppelins, derail trains, implode bridges, destroy armored tanks, and level enemy facilities in the name of vengeance, in the first open-world action game set in Nazi-occupied Europe.", Price = 59.99m, ReleaseDate = new DateTime(2009, 12, 8), ImageUrl = "http://www.xbox.com/NR/rdonlyres/F080BEE0-5DBD-4B30-859E-8E72F4B4C0D4/0/boxsaboteur.jpg", Genre = "Action", Publisher = "Pandemic Studios", Developer = "Pandemic Studios", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Call of Duty® Classic", Description = "For the first time ever, Infinity Ward's 2003 award-winning game that launched a franchise comes to consoles in Call of Duty Classic. Relive the original Call of Duty experience in high definition, including online multiplayer on Xbox LIVE with Leaderboard support.", Price = 0m, ReleaseDate = new DateTime(2009, 12, 2), ImageUrl = "http://www.xbox.com/NR/rdonlyres/833A0475-DFF5-434E-B245-96A9BE4ACEFC/0/boxcallofdutyclassicxbla.jpg", Genre = "Shooter", Publisher = "Infinity Ward, Aspyr", Developer = "Infinity Ward, Aspyr", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "James Cameron's Avatar: The Game", Description = "James Cameron's Avatar: The Game is the official video game based on the highly anticipated film James Cameron's Avatar.Â The video game will take you deep into the heart of Pandora, an alien planet that is beyond imagination.Â ", Price = 59.99m, ReleaseDate = new DateTime(2009, 12, 1), ImageUrl = "http://www.xbox.com/NR/rdonlyres/24F9CFB1-41AD-47E0-B31E-D93560851EE8/0/boxavataren.jpg", Genre = "Action", Publisher = "Ubisoft Montreal", Developer = "Ubisoft Montreal", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Rogue Warrior™", Description = "Rogue Warrior is a character-driven first-person-shooter, featuring Richard â€œDemo Dickâ€ Marcinkoâ€™s explosive personality in an action-packed single player campaign, and intense multiplayer combat. Playing as Richard â€œDemo Dickâ€ Marcinko,Â go behind the Iron Curtain to disrupt a suspected North Korean ballistic missile program.Â Soon into the mission, you uncover a conspiracy that could turn the tides of the Cold War in the favor of the Communists. Take the mission into your own hands as you enter into the bowels of the USSR to destroy a technology that could change the balance of geopolitical power, leaving a trail of destruction in your wake!", Price = 59.99m, ReleaseDate = new DateTime(2009, 12, 1), ImageUrl = "http://www.xbox.com/NR/rdonlyres/28323522-F73D-4FFD-9E77-F7933BB7C1C7/0/boxroguewarrior.jpg", Genre = "Shooter", Publisher = "Rebellion", Developer = "Rebellion", GameRating = ESRBRating.Lookup("M (Mature)"),  });
      Add(new Game() { Name = "Planet 51™", Description = "Planet 51, the white picket-fence world reminiscent of 1950s America is happy, safe and predictable ... until the unpredictable happens! Out of the blue, Captain Charles “Chuck“ Baker's spaceship comes crashing down. Unaware of his surroundings, Chuck begins to realize he is not alone. Taking refuge while planning his return home, Chuck meets green-skinned local Lem, and discovers that he may be the real “alien“ after all!  Join the space race as you explore the world of Planet 51 and test your skills in a series of action-filled adventures based on the upcoming family movie.", Price = 49.95m, ReleaseDate = new DateTime(2009, 11, 26), ImageUrl = "http://www.xbox.com/NR/rdonlyres/C8E29C87-FD7E-45D2-A26D-B2300AA54DBE/0/boxplanet51.jpg", Genre = "Racing", Publisher = "Pyro Studios", Developer = "Pyro Studios", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "Madden NFL Arcade", Description = "Feel the excitement of the NFL with a fun, fast-paced, 5-on-5 football experience. Madden NFL Arcade for Xbox LIVE Arcade brings the 10 best players from each of the 32 NFL teams on offense and defense together to battle it out on the gridiron. No penalties, no clock, just pure adrenaline, as each team has four downs to march 60 yards downfield for the score. Madden NFL Arcade takes everything you love about your favorite NFL stars and stadiums and brings them to life in a fun, high-scoring gridiron battle!", Price = 0m, ReleaseDate = new DateTime(2009, 11, 25), ImageUrl = "http://www.xbox.com/NR/rdonlyres/D0CBA45A-E1AA-49CC-ACAC-96CC5DEF4227/0/boxmaddennflarcade.jpg", Genre = "Sports Games", Publisher = "", Developer = "", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "Diner Dash ®", Description = "Diner DashÂ®, the number one PC time-management game has landed onto Xbox LIVEÂ®!Â Guide Flo, a former office-worker turned restaurateur, as she builds up her diner empire.Â Go online and face players in head to head matches to see who's the best Flo. Join up with a friend or another player online for a Team Dash game where your teamÂ takes on six other players to see whose diner is the best in town. ", Price = 0m, ReleaseDate = new DateTime(2009, 11, 18), ImageUrl = "http://www.xbox.com/NR/rdonlyres/2154DE33-3197-4E8E-BA6B-E2A1585433BA/0/boxdinerdash.jpg", Genre = "Family Games", Publisher = "Backbone Entertainment", Developer = "Backbone Entertainment", GameRating = ESRBRating.Lookup("E (Everyone)"),  });
      Add(new Game() { Name = "Gyromancer™", Description = "Gyromancer is a puzzle-role playing game (RPG) featuring a unique battle system based on Bejeweled Twist combined with elements of Square Enix role-playing games. This is one experience you won't want to miss. Try it now!", Price = 0m, ReleaseDate = new DateTime(2009, 11, 18), ImageUrl = "http://www.xbox.com/NR/rdonlyres/52B1680A-3604-4146-B08B-F3242B18711B/0/boxgyromancer.jpg", Genre = "Role Playing Games", Publisher = "SQUARE ENIX", Developer = "SQUARE ENIX", GameRating = ESRBRating.Lookup("T (Teen)"),  });
      Add(new Game() { Name = "Assassin's Creed™ II", Description = "Betrayed by the ruling families of Italy, a young man embarks upon an epic quest for vengeance in Assassin's Creed II. To his allies, he will become a force for changeâ€”fighting for freedom and justice. To his enemies, he will become a boogey manâ€”dedicated to the destruction of the tyrants abusing the people of Italy.", Price = 59.99m, ReleaseDate = new DateTime(2009, 11, 17), ImageUrl = "http://www.xbox.com/NR/rdonlyres/0EF6DA61-4657-4779-8D73-02600470F803/0/boxassasinscreed2.jpg", Genre = "Action", Publisher = "Ubisoft Montreal", Developer = "Ubisoft Montreal", GameRating = ESRBRating.Lookup("M (Mature)"),  });

    }
  }
}