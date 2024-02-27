using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Models.ModelAnglais;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;

namespace arsoudServeur.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //Seed IdentityUsers

            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser adminUser = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",

                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true
            };
            IdentityUser utilisateur1 = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "user1@hotmail.com",
                Email = "user1@hotmail.com",

                NormalizedUserName = "USER1@HOTMAIL.COM",
                NormalizedEmail = "USER1@HOTMAIL.COM",
                EmailConfirmed = true
            };
            IdentityUser utilisateur2 = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111113",
                UserName = "user2@hotmail.com",
                Email = "user2@hotmail.com",

                NormalizedUserName = "USER2@HOTMAIL.COM",
                NormalizedEmail = "USER2@HOTMAIL.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Passw0rd!");
            utilisateur1.PasswordHash = hasher.HashPassword(utilisateur1, "Passw0rd!");
            utilisateur2.PasswordHash = hasher.HashPassword(utilisateur2, "Passw0rd!");

            builder.Entity<IdentityUser>().HasData(adminUser, utilisateur1, utilisateur2);

            // Seed utilisateurs
            List<Utilisateur> utilisateurs = new List<Utilisateur>()
            {
                new Utilisateur
                {
                    id = 1,
                    nom = "tangerine",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "Administrator",
                    courriel = adminUser.UserName,
                    adresse = "",
                    identityUserId = adminUser.Id,
                },
                new Utilisateur
                {
                    id = 2,
                    nom = "Hogan",
                    prenom = "Hulk",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur1.UserName,
                    adresse = "",
                    identityUserId = utilisateur1.Id,
                },
                new Utilisateur
                {
                    id = 3,
                    nom = "Charles",
                    prenom = "Grégory",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur2.UserName,
                    adresse = "1260, rue Mill, suite 100",
                    identityUserId = utilisateur2.Id,
                },
            };

            builder.Entity<Utilisateur>().HasData(utilisateurs);
            SeedRandonnees(builder);
            SeedGPSData(builder);
            SeedCommentaires(builder);
            SeedCommentairesAnglais(builder);
            SeedPublication(builder);
        }



        private void SeedPublication(ModelBuilder builder)
        {
            var publications = new List<Publication>
            {
                new Publication
                {
                    id = 1,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 1,
                    utilisateurId = 1,

                },
                new Publication
                {
                    id = 2,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 2,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 3,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 3,
                    utilisateurId = 3,
                },
                new Publication
                {
                    id = 4,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 4,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 5,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 5,
                    utilisateurId = 2,
                },
                new Publication
                {
                    id = 6,
                    etat = Publication.EtatPublication.Publique,
                    randonneeId = 6,
                    utilisateurId = 1,
                }
            };

            builder.Entity<Publication>().HasData(publications);
        }

        private void SeedRandonnees(ModelBuilder builder)
        {
            var randonnees = new List<Randonnee>
            {
                new Randonnee
                {
                    id = 1,
                    nom = "St-Brun",
                    description = "promenade cool a st-brun",
                    emplacement = "st-bruno",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Publique
                },
                new Randonnee
                {
                    id = 2,
                    nom = "ptite marche au subway",
                    description = "promenade moyennement cool la bas",
                    emplacement = "dehors",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique
                },
                new Randonnee
                {
                    id = 3,
                    nom = "Brossard",
                    description = "promenade fresh a bro s s a r d",
                    emplacement = "st-hilaire?",
                    utilisateurId = 3,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Publique
                },
                new Randonnee
                {
                    id = 4,
                    nom = "ma randonnée pédestre",
                    description = "promenade au subway",
                    emplacement = "st-grégoire",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique
                },
                new Randonnee
                {
                    id = 5,
                    nom = "rivière rouge",
                    description = "ça doit être cool la bas",
                    emplacement = "quelque part",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique      
                },
                new Randonnee
                {
                    id = 6,
                    nom = "Ma randonnée",
                    description = "je pense qu'on a beaucoup de fun",
                    emplacement = "mont tremblant",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique
                }
            };

            var randonneesAnglais = new List<RandonneeAnglais>
            {
                new RandonneeAnglais
                {
                    id = 1,
                    nom = "St-Bruno",
                    description = "Cool walk in St-Bruno",
                    emplacement = "St-Bruno",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 1,
                },
                new RandonneeAnglais
                {
                    id = 2,
                    nom = "Little Walk to Subway",
                    description = "Moderately cool walk there",
                    emplacement = "Outside",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 2,
                },
                new RandonneeAnglais
                {
                    id = 3,
                    nom = "St-Hilaire",
                    description = "Fresh walk in St-Hilaire",
                    emplacement = "St-Hilaire",
                    utilisateurId = 3,
                    typeRandonnee = Randonnee.Type.Vélo,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 3,
                },
                new RandonneeAnglais
                {
                    id = 4,
                    nom = "My Hiking Trip",
                    description = "Walk to Subway",
                    emplacement = "St-Grégoire",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 4,
                },
                new RandonneeAnglais
                {
                    id = 5,
                    nom = "Red River",
                    description = "It must be cool there",
                    emplacement = "Somewhere",
                    utilisateurId = 2,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 5,
                },
                new RandonneeAnglais
                {
                    id = 6,
                    nom = "My Trek",
                    description = "I think it's a lot of fun",
                    emplacement = "Mont Tremblant",
                    utilisateurId = 1,
                    typeRandonnee = Randonnee.Type.Marche,
                    etatRandonnee = Randonnee.Etat.Publique,
                    randonneeId = 6,
                },
            };

            builder.Entity<Randonnee>().HasData(randonnees);
            builder.Entity<RandonneeAnglais>().HasData(randonneesAnglais);
        }

        private void SeedGPSData(ModelBuilder builder)
        {
            var gpsData = new List<GPS>
            {
                new GPS
                {
                    id = 1,
                    x = 45.53665313486474,
                    y = -73.49497434095912,
                    depart = true,
                    randonneeId = 1,
                    randonneAnglaisId = 1,
                },
                new GPS
                {
                    id = 2,
                    x = 45.63665313486474,
                    y = -73.59497434095912,
                    arrivee = true,
                    randonneeId = 1,
                    randonneAnglaisId = 1,
                },
                new GPS
                {
                    id = 3,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 2,
                    randonneAnglaisId = 2,
                },
                new GPS
                {
                    id = 4,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 2,
                    randonneAnglaisId = 2,
                },
                new GPS
                {
                    id = 5,
                    x = 45.538015,
                    y = -73.156983,
                    depart = true,
                    randonneeId = 3,
                    randonneAnglaisId = 3,
                },
                new GPS
                {
                    id = 6,
                    x = 45.63665313486474,
                    y = -73.59497434095912,
                    arrivee = true,
                    randonneeId = 3,
                    randonneAnglaisId = 3,
                },
                new GPS
                {
                    id = 7,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 4,
                    randonneAnglaisId = 4,
                },
                new GPS
                {
                    id = 8,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 4,
                    randonneAnglaisId = 4,
                },
                new GPS
                {
                    id = 9,
                    x = 45.354999,
                    y = -73.150238,
                    depart = true,
                    randonneeId = 5,
                    randonneAnglaisId = 5,
                },
                new GPS
                {
                    id = 10,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 5,
                    randonneAnglaisId = 5,
                },
                new GPS
                {
                    id = 11,
                    x = 45.354999,
                    y = -73.160238,
                    depart = true,
                    randonneeId = 6,
                    randonneAnglaisId = 6,
                },
                new GPS
                {
                    id = 12,
                    x = 45.356925,
                    y = -73.150234,
                    arrivee = true,
                    randonneeId = 6,
                    randonneAnglaisId = 6,
                }

            };

            builder.Entity<GPS>().HasData(gpsData);
        }
        private void SeedCommentaires(ModelBuilder builder)
        {
            var commentaireData = new List<Commentaire>
            {
                //Descriptions générées avec https://randomgenerate.io/ai-review-generator
                new Commentaire
                {
    id = 1,
    message = "Cherchez-vous une nouvelle aventure en plein air qui ne vous ruinera pas ? Ne cherchez pas plus loin qu'Arsoude ! Cette application propose une grande variété de sentiers de randonnée à des prix abordables, ce qui permet à tout le monde de découvrir la beauté de la nature sans dépenser une fortune. Avec Arsoude, vous pouvez facilement trouver de nouveaux sentiers à explorer en fonction de votre emplacement et de votre niveau de compétence. L'application fournit des informations détaillées sur chaque sentier, y compris la distance, le niveau de difficulté et les avis des utilisateurs, afin que vous puissiez choisir la randonnée parfaite pour votre prochaine sortie.",
    randonneeId = 1,
    utilisateurId = 2,
    note = 3,
    isDeleted = false,
},
new Commentaire
{
    id = 2,
    message = "J'ai récemment téléchargé l'application de randonnée Arsoude et je dois dire que je suis extrêmement impressionné. L'application est conviviale et fournit des cartes détaillées, des informations sur les sentiers et des conseils pour les randonneurs de tous niveaux. J'apprécie qu'elle inclue des fonctionnalités telles que le suivi GPS et les cartes hors ligne, ce qui permet de naviguer facilement même dans des zones reculées sans signal. Les recommandations de sentiers et les niveaux de difficulté sont précis et m'ont aidé à découvrir de nouvelles randonnées que je n'aurais jamais découvertes autrement. En somme, Arsoude est devenue mon application de prédilection pour toutes mes aventures de randonnée. Je le recommande vivement !",
    randonneeId = 2,
    utilisateurId = 1,
    note = 3,
    isDeleted = false,
},
new Commentaire
{
    id = 3,
    message = "En tant que randonneur passionné, je ne peux que recommander l'application Arsoude. Cette plateforme conviviale a complètement révolutionné mon expérience de randonnée. Des cartes de sentiers détaillées aux mises à jour météorologiques en temps réel, Arsoude a tout ce dont j'ai besoin pour planifier et exécuter la parfaite aventure en plein air. L'interface est élégante et intuitive, ce qui facilite la navigation même en déplacement. De plus, la fonctionnalité de communauté me permet de me connecter avec d'autres amateurs de plein air et de partager des conseils et des recommandations. Que vous soyez un randonneur chevronné ou un débutant, Arsoude est un incontournable pour votre prochaine excursion en plein air.",
    randonneeId = 2,
    utilisateurId = 2,
    note = 3,
    isDeleted = false,
},
new Commentaire
{
    id = 4,
    message = "Arsoude est une application de randonnée fantastique qui a complètement changé la façon dont j'explore la nature. Avec des cartes de sentiers détaillées, le suivi GPS et les mises à jour météorologiques en temps réel, je peux partir en toute confiance dans de nouvelles aventures sans craindre de me perdre. L'application propose également un forum communautaire où les utilisateurs peuvent partager des conseils, des photos et des recommandations, ce qui facilite la connexion avec d'autres passionnés de plein air. En résumé, Arsoude est devenue un outil indispensable pour mes excursions de randonnée et je le recommande vivement à quiconque souhaite découvrir de nouveaux sentiers.",
    randonneeId = 2,
    utilisateurId = 3,
    note = 1,
    isDeleted = false,
},
new Commentaire
{
    id = 5,
    message = "J'ai récemment découvert l'application de randonnée Arsoude et je dois dire que je suis impressionné. Non seulement elle est facile à utiliser, mais elle offre également une multitude d'itinéraires de randonnée à travers de superbes paysages. Grâce à Arsoude, j'ai pu explorer de nouveaux sentiers et découvrir des trésors cachés que je n'aurais jamais trouvés autrement. Je recommande vivement cette application à tous les amoureux de la randonnée!",
    randonneeId = 6,
    utilisateurId = 3,
    note = 5,
    isDeleted = false,
},
                 new Commentaire
                 {
                     id = 6,
                     message = "Imagine si quelqu'un comme ça a des enfants. Comme imagine. Imagine si quelqu'un comme ça a des enfants. Je vais tellement avoir pitié de ses enfants parce que le mec ne sert littéralement à rien. Imagine un père, maintenant on a plein de mecs avec femme et enfants et tout ça qui continuent à me sucer la bite quotidiennement sur internet, mais imagine si ce mec avait réellement des enfants. Ce mec consacre le temps qu'il pourrait passer avec ses enfants à regarder un homme noir en streaming, le cuckant sans relâche. C'est fou ! Je n'ai jamais vu quelqu'un aussi acharné à être vu. Quelqu'un d'aussi sans valeur qu'il revient sans cesse dans ce stream et qu'on te bannisse encore et encore et encore et encore et encore.\r\nMec laisse-moi.. laisse-moi.. faisons-toi une faveur.",
                     randonneeId = 6,
                     utilisateurId = 1,
                     note = 5,
                     isDeleted = false,
                 },
                 new Commentaire
                 {
                    id = 7,
                    message = "Allons au magasin à 1 euro et choisissons une corde ensemble. Je vais te donner un suicide assisté. Choisissons une corde ensemble, d'accord ? Et on va prendre tous les meilleurs clips de trolls, mettre un écran de télé devant toi.\r\nJe vais accrocher cette corde en haut du putain de garage.\r\nOn va t'ouvrir les yeux de force, on n'aura probablement même pas besoin de le faire car tu es sur ma bite tous les jours. On va t'ouvrir les yeux jusqu'à ce que tu regardes constamment des clips encore et encore et encore jusqu'à ce que tu te dises 'Attends une minute, c'est un peu trop'\r\nTu vas juste commencer à devenir fou.\r\nTu vas commencer à devenir fou.\r\nJuste, tes yeux vont saigner, tes rétines vont juste commencer à couler, à sortir des fissures et des veines dans tes rétines vont commencer à se déclencher et à gonfler. Ensuite, je vais attraper cette corde pour toi et dire 'Tu es prêt ?' Tu vas dire 'Ouais' Je vais la prendre et TE TRAÎNER\r\npendant que tu me supplie, me supplie et je veux dire me supplie de te tuer et de t'étrangler, étrangler la vie sans valeur de ton putain de cul jusqu'à ce que tu sois mort, crevé avec un visage bleu mec. Parce que tu ne mérites pas ton âme.\r\nJe n'ai jamais vu quelqu'un d'aussi putain de sans valeur et acharné qui continue à venir dans le chat d'un mec encore et encore et encore. Quelqu'un comme ça doit mourir.\r\nIl n'y a vraiment aucune raison pour lui de vivre. Nous avons perdu des mecs éminents sur terre, qui servaient un but qui avaient... alors ce mec pourrait être sur terre en train de troller un stream quotidiennement, comme viens sur mon mec. Comme, ta vie est juste sans valeur, s'il te plaît, tue-toi.\r\nSors, jette des steaks dans une ruelle et espère qu'une bande de chiens errants te sautent dessus commence à mâcher ta putain de bite, ta bite, à en mordre des morceaux et tout ça parce que tu dois juste partir. Comme ce mec hors de la terre. S'il te plaît",
                    randonneeId = 3,
                    utilisateurId = 3,
                    note = 1,
                    isDeleted = false,
                 },
                 new Commentaire
                 {
                    id = 8,
                    message = "Tu es une salope sans valeur\r\nTa vie est littéralement aussi précieuse qu'une fourmi d'été. Je vais juste t'écraser.\r\nTu vas continuer à revenir. Je vais sceller toutes mes fissures, tu vas continuer à revenir\r\nPourquoi ? Parce que tu continues à sentir le sirop, tu es une salope sans valeur. Tu vas rester sur ma bite jusqu'à ce que tu meures.\r\nTu ne sers à rien dans la vie. Ton but dans la vie est d'être sur mon stream à sucer ma bite quotidiennement.",
                    randonneeId = 1,
                    utilisateurId = 3,
                    note = 4,
                    isDeleted = false,
                   },
            };
            builder.Entity<Commentaire>().HasData(commentaireData);
        }

        private void SeedCommentairesAnglais(ModelBuilder builder)
        {
            var commentaireData = new List<CommentaireAnglais>
            {
                //Descriptions générées avec https://randomgenerate.io/ai-review-generator
                new CommentaireAnglais
                {
                    id = 1,
                    message = "Are you looking for a new outdoor adventure that won't break the bank? Look no further than Arsoude! This app offers a wide variety of hiking trails at affordable prices, making it easy for anyone to experience the beauty of nature without spending a fortune. With Arsoude, you can easily find new trails to explore based on your location and skill level. The app provides detailed information about each trail, including distance, difficulty level, and user reviews, so you can choose the perfect hike for your next outing.",
                    randonneeId = 1,
                    commentaireId = 1,
                },
                new CommentaireAnglais
                {
                    id = 2,
                    message = "I recently downloaded the hiking app Arsoude and I have to say I am extremely impressed. The app is user-friendly and provides detailed maps, trail information, and tips for hikers of all levels. I love that it includes features such as GPS tracking and offline maps, making it easy to navigate even in remote areas with no signal. The trail recommendations and difficulty ratings have been spot on and have helped me find new hikes that I never would have discovered otherwise. Overall, Arsoude has become my go-to app for all of my hiking adventures. Highly recommend!",
                    randonneeId = 2,
                    commentaireId = 2

                },
                new CommentaireAnglais
                {
                    id = 3,
                    message = "As an avid hiker, I cannot recommend the Arsoude app enough. This user-friendly platform has completely revolutionized my hiking experience. From detailed trail maps to real-time weather updates, Arsoude has everything I need to plan and execute the perfect outdoor adventure. The interface is sleek and intuitive, making it easy to navigate even on the go. Plus, the community feature allows me to connect with other outdoor enthusiasts and share tips and recommendations. Whether you're a seasoned hiker or just starting out, Arsoude is a must-have for your next outdoor excursion.",
                    randonneeId = 2,
                    commentaireId = 3
                },
                new CommentaireAnglais
                {
                    id = 4,
                    message = "Arsoude is a fantastic hiking app that has completely changed the way I explore the great outdoors. With detailed trail maps, GPS tracking, and real-time weather updates, I can confidently go on new adventures without worrying about getting lost. The app also features a community forum where users can share tips, photos, and recommendations, making it easy to connect with other outdoor enthusiasts. Overall, Arsoude has become an essential tool for my hiking excursions and I highly recommend it to anyone looking to discover new trails.",
                    randonneeId = 2,
                    commentaireId = 4
                },
                new CommentaireAnglais
                {
                    id = 5,
                    message = "J'ai récemment découvert l'application de randonnée Arsoude et je dois dire que je suis impressionné. Non seulement elle est facile à utiliser, mais elle offre également une multitude d'itinéraires de randonnée à travers de superbes paysages. Grâce à Arsoude, j'ai pu explorer de nouveaux sentiers et découvrir des trésors cachés que je n'aurais jamais trouvés autrement. Je recommande vivement cette application à tous les amoureux de la randonnée!",
                    randonneeId = 6,
                    commentaireId = 5
                },
                 new CommentaireAnglais
                {
                    id = 6,
                    message = "Imagine if a nigga like that has kids. Like imagine. Imagine if somebody like that has kids. I will feel so sorry for his children cause the nigga literally serves no purpose. Imagine a father, now we got a lot of niggas with wife and kids and shit like that who keeps sucking on my dick daily on the internet but imagine if this nigga actually had children. This niggas devoting the time he could be spending with his kids checking out a black man on stream cucking him relentlessly. That's crazy! I've never seen somebody so relentless to be seen. Somebody so worthless that they'll come into this stream and keep coming in this bitch over and over and over and over and over again when we keep banning you\r\nNigga let me.. let me.. let's do you a favor.",
                    randonneeId = 6,
                    commentaireId = 6
                },
                 new CommentaireAnglais
                {
                    id = 7,
                    message = "Lets go to the 99 cents store and lets pick out a rope together. Imma give you an assisted suicide. Lets pick out a rope together right? And we're gonna take all the greatest trolls clips, put a tv screen right in front of you.\r\nI'm gonna hang that rope at the top of the motherfucking garage.\r\nWe're gonna forcefully pry your eyes open, we probably don't even need to do that cause your on my dick daily. We're gonna pry your eyes open until you consistently watch clips over and over and over and over again to the point where you're gonna be like 'Wait a minute, this is a little bit too much'\r\nYou're just gonna start going crazy.\r\nYou're gonna start going crazy.\r\nJust, your eyes are gonna bleed your retinas are just gonna start pouring out, pouring out blood and just getting\r\ncracks and veins in your retinas are gonna start engaging and bulging. Then I'm gonna grab that rope for you and say 'Are you ready?' You're gonna say 'Yeah' I'm gonna take it and PULL IT\r\nwhile you beg me, beg me and I mean beg me to kill you and choke you, choke the worthless life out of your sorry ass until you're fucking dead, croaked with a blue face nigga. Cause you don't deserve your soul.\r\nI've never seen somebody so fucking worthless and relentless that keep coming in a niggas chat over and over and over again. Somebody like that needs to die.\r\nThere is really no reason for him to be alive. We lost prominent niggas on earth, that served a purpose that had... so this nigga could be on earth trolling a stream daily, like come on my nigga. Like, your life is just worthless, just please kill yourself.\r\nGo outside, throw some steaks in a fucking alley and hope a bunch of stray dogs jump on you starts chewing your fucking dick your dick off, biting pieces and shit off of you like that cause you literally just gotta go. Like this nigga off of earth. Please",
                    randonneeId = 3,
                    commentaireId = 7
                },
                 new CommentaireAnglais
                {
                    id = 8,
                    message = "You are a worthless bitch ass nigga\r\nYour life literally is as valuabke as a summer ant. I'm just gonna stomp you.\r\nYou're gonna keep coming back. I'm gonna seal up all my cracks, youre gonna keep coming back\r\n \r\nWhy? Cause you keep smelling the syrup, you worthless bitch ass nigga. Your gonna stay on my dick until you die.\r\nYou serve no purpose in life. Your purpose in life is to be on my stream sucking on my dick daily.",
                    randonneeId = 1,
                    commentaireId = 8
                },
            };
            builder.Entity<CommentaireAnglais>().HasData(commentaireData);
        }

        public DbSet<Utilisateur> utilisateurs { get; set; } = default!;
        public DbSet<Randonnee> randonnees { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<GPS> gps { get; set; } = default!;
        public DbSet<Commentaire> commentaires { get; set; } = default!;
        public DbSet<RandonneeUtilisateurTrace> utilisateursTrace { get; set; } = default!;
        public DbSet<Avertissement> avertissements { get; set; } = default!;
        public DbSet<RandonneeAnglais> randonneeAnglais { get; set; } = default!;
        public DbSet<CommentaireAnglais> commentaireAnglais { get; set; } = default!;
        public DbSet<AvertissementAnglais> avertissementAnglais { get; set; } = default!;
        public DbSet<Publication> publication { get; set; } = default!;
        public DbSet<PublicationUtilisateur> Like { get; set; } = default!;
    }
}
