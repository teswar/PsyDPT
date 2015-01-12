namespace Psydpt.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Psydpt.Data.Entities;
    using Psydpt.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Psydpt.Data.PsydptContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Psydpt.Data.PsydptContext";
        }

        protected override void Seed(Psydpt.Data.PsydptContext context)
        {
            //  This method will be called after migrating to the latest version.
            var userManager = new UserManager<Entities.AppUser>(new UserStore<Entities.AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Adding Roles
            #region Roles

            var roles = new List<IdentityRole>();
            roles.Add(new IdentityRole(UserRole.Admin.ToString()));
            roles.Add(new IdentityRole(UserRole.Patient.ToString()));
   
            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role.Name)) { roleManager.Create(role); }
            }

            #endregion


            // Adding Admin account
            #region Users

            if (userManager.FindByEmail("admin@psydpt.com") == null)
            {
                var adminUser = new Entities.AppUser()
                {
                    Email = "admin@psydpt.com",
                    UserName = "Admin"
                };
                userManager.Create(adminUser, "1qaz2wsx");
                userManager.AddToRole(adminUser.Id, UserRole.Admin.ToString());
            }

            if (userManager.FindByEmail("patient@psydpt.com") == null)
            {
                var adminUser = new Entities.AppUser()
                {
                    Email = "patient@psydpt.com",
                    UserName = "Patient"
                };
                userManager.Create(adminUser, "1qaz2wsx");
                userManager.AddToRole(adminUser.Id, UserRole.Patient.ToString());
            }

            #endregion


            // Adding disorders
            #region Disorders

            var disorders = new List<Disorder>();
            disorders.Add(new Disorder()
                {
                    Name = "Aboulia",
                    Keywords = "loss, spontaneous, movement, reduce, drive, expression, behavior, slow, speech, response-time, social, interaction",
                    Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                    CreatedOn = DateTime.Now
                });

            disorders.Add(new Disorder()
            {
                Name = "Absence seizure / Epilepsy",
                Keywords = "suddenly, unconscious, response, rolled, eyes",
                Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                CreatedOn = DateTime.Now
            });

            disorders.Add(new Disorder()
            {
                Name = "Agoraphobia",
                Keywords = "open, space, wide, panic, environment, crowd, public, society, place, separation, fear, scared",
                Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                CreatedOn = DateTime.Now
            });

            disorders.Add(new Disorder()
             {
                 Name = "Alzheimer's disease",
                 Keywords = "memory loss, spontaneous, movement, reduce, drive, expression, behavior, slow, speech, response-time, social, interaction",
                 Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                 CreatedOn = DateTime.Now
             });

            disorders.Add(new Disorder()
             {
                 Name = "Autism",
                 Keywords = "eat, food, restrict, weight, thin, habit, meals, fat, lack, appetite, loss, obsession, purging, vomiting, calories",
                 Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                 CreatedOn = DateTime.Now
             });

            disorders.Add(new Disorder()
            {
                Name = "Asperger syndrome",
                Keywords = "child, lack, social, interaction, communication, talk, repetitive, beahviour, lonely, ritual, self-injury, withdrawn, reserved",
                Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                CreatedOn = DateTime.Now
            });

            disorders.Add(new Disorder()
            {
                Name = "Anorexia Nervosa",
                Keywords = "lack, social, interaction, posture, eye-contact, repetitive, beahviour, abnormal, sleep, moves, flap, hands",
                Description = "E.g: Recently my daughter has refused to eat food at all. She does not take any meals from home or outside. She has been frettng  a lot that she has gained weight even though she is very thin.",
                CreatedOn = DateTime.Now
            });


            foreach (var disorder in disorders)
            {
                if (context.Disorders.Any(m => (m.Name.Equals(disorder.Name, StringComparison.InvariantCultureIgnoreCase)))) { continue; }
                context.Disorders.Add(disorder);
            }

            #endregion


            // Adding POS tags used in the Penn Treebank

            #region POS tags

            var postags = new List<PredictionPuntuation>();

            postags.Add(new PredictionPuntuation() { Code = "CC", Word = "Coordinating conjunction", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "CD", Word = "Cardinal number", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "DT", Word = "Determiner", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "EX", Word = "Existential there", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "FW", Word = "Foreign word", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "IN", Word = "Preposition or subordinating conjunction", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "JJ", Word = "Adjective", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "JJR", Word = "Adjective, comparative", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "JJS", Word = "Adjective, superlative", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "LS", Word = "List item marker", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "MD", Word = "Modal", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "NN", Word = "Noun, singular or mass", IsActive = true });
            postags.Add(new PredictionPuntuation() { Code = "NNS", Word = "Noun, plural", IsActive = true });
            postags.Add(new PredictionPuntuation() { Code = "NNP", Word = "Proper noun, singular", IsActive = true });
            postags.Add(new PredictionPuntuation() { Code = "NNPS", Word = "Proper noun, plural", IsActive = true });
            postags.Add(new PredictionPuntuation() { Code = "PDT", Word = "Predeterminer", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "POS", Word = "Possessive ending", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "PRP", Word = "Personal pronoun", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "PRP$", Word = "Possessive pronoun", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "RB", Word = "Adverb", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "RBR", Word = "Adverb, comparative", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "RBS", Word = "Adverb, superlative", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "RP", Word = "Particle", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "SYM", Word = "Symbol", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "TO", Word = "to", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "UH", Word = "Interjection", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "VB", Word = "Verb, base form", IsActive = true });
            postags.Add(new PredictionPuntuation() { Code = "VBD", Word = "Verb, past tense", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "VBG", Word = "Verb, gerund or present participle", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "VBN", Word = "Verb, past participle", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "VBP", Word = "Verb, non-3rd person singular present", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "VBZ", Word = "Verb, 3rd person singular present", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "WDT", Word = "Wh-determiner", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "WP", Word = "Wh-pronoun", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "WP$", Word = "Possessive wh-pronoun", IsActive = false });
            postags.Add(new PredictionPuntuation() { Code = "WRB", Word = "Wh-adverb", IsActive = false });

            foreach (var item in postags)
            {
                if (context.PredictionPuntuations.FirstOrDefault(m 
                    => m.Code.Equals(item.Code, StringComparison.InvariantCultureIgnoreCase)) != null) { continue; }

                context.PredictionPuntuations.Add(item);
            }

            #endregion

            context.SaveChanges();
        }
    }
}
