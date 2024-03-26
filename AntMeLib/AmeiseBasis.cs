﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntMeLib
{
    public abstract class AmeiseBasis : iAnt
    {
        public static string[] NameList = { "Lotte", "Evelyn", "Celina", "Gerhard", "Sami", "Carolin", "Alexia", "Pina", "Nisanur", "Genevieve", "Miriam", "Ecrin", "Giuliano", "Naoual", "Erik", "Lina", "Damien", "Svea", "Eva", "Juri", "Gleb", "Rufus", "Ramona", "Gaetano", "Karlotta", "Juli", "Abdellah", "Mia", "Georgiev", "Meike", "Enrique", "Zakariya", "Aziz", "Janis", "Sultan", "Kira", "Jakob", "Nora", "Collin", "Alper", "Eren", "Philipp", "Maria", "Giovanni", "Anna-Lena", "Rawan", "Lucia", "Boris", "Lina-Marie", "Luzia", "Veli", "Danny", "Cheyenne", "Ceren", "Adriana", "Djamila", "Mateo", "Heinrich", "Metehan", "Maximiliane", "Eda", "Ipek", "Mylie", "Berke", "Lisann", "Eckhard", "Marvin", "Giuliana", "Margot", "Bernd", "Robin", "Bekir", "del", "Angelo", "Narin", "Vitaljewitsch", "Benedikt", "Herbert", "Theo", "Carlo", "Levin", "Bennet", "Cassandra", "Yasin", "Natalie", "Tilda", "Tiam", "Ivanov", "Lena", "Ellen", "Aminata", "Karl", "Tereza", "Alexandros", "Melisa", "Aron", "Beyza", "Medine", "Lionel", "Isabel", "Dima", "Jason", "Maja", "Athina", "Ilvy", "Valeska", "Florian", "Ata", "Yegor", "Michele", "Konstantina", "Nea", "Marina", "Noa", "Afrakoma", "Moritz", "Mohammad", "Nour", "Raffael", "Mohammed", "Sophie", "Einar", "Beat", "Mehmet", "Ilya", "Lutz", "Lilli", "Elaine", "Leila", "Alperen", "Hermann", "Angeli", "Amina", "Delya", "Lucy", "Evren", "Ursula", "Emilie", "Lee", "Mattis", "Matilda", "Rachel", "Neo", "Mailo", "Bela", "Frederick", "Simeon", "Anouk", "Janusz", "Ewa", "Sebastian", "Orlando", "Esat", "Nisa", "Marta", "Susanne", "Simona", "Kilian", "Jarne", "Frieder", "Muhsin", "Jarno", "Giovanna", "Diogo", "Mona", "Ruth", "Yassin", "Dila", "Luise", "Alica", "Malak", "Luca", "Blanca", "Roni", "Filippa", "Deniz", "Lovis", "Cem", "Namarig", "Sinem", "Karolin", "Giulia", "Ekrem", "Valentino", "Alan", "Marlena", "Greta", "Dominik", "Anja", "Akram", "Muhammed", "Valerie", "Lazo", "Abdulrahman", "Lennox", "Celine", "Eclin", "Rohat", "Emanuel", "Cedric", "Lio", "Leonie", "Mathilda", "Arian", "Patrick", "Antonie", "Inga", "Hatem", "Viktor", "Merlin", "Ahmad", "Efe", "Johanna", "Fiona", "Sahra", "Ryan", "Adem", "Philemon", "Iris", "Liya", "Carlotta", "Tahir", "Carl", "Malina", "Bernard", "Anette", "Diego", "Pia", "Sipan", "Lisanne", "Angelina", "Phillip", "Alejandra", "Asia", "Alexandra", "Sercan", "Bert", "Phil", "Roy", "Laila", "Lilly", "Yolanda", "Jano", "Levi", "Manuel", "Ismael", "Lino", "Gianluca", "Jayden", "Nathaniel", "Elise", "Aurel", "Jakub", "Polat", "Kiyan", "Bo", "Roya", "Edward", "Sara", "Barbara", "Joachim", "Semih", "Chanel", "Chelsea", "Aliyah", "Ahmed", "Maximilian", "Tamara", "Lauren", "Nayla", "Amir", "Ravza", "Finja", "Havin", "Fernando", "Astrid", "Philip", "Alissa", "Malte", "Aliya", "Bryan", "Lias", "Raffaello", "Jannis", "Cornelius", "Lisbeth", "Janna", "Milena", "Angela", "Leona", "Vincenzo", "Tuana", "Adriano", "Shayla", "Fatih", "Desiree", "Koray", "Jula", "Tim", "Anika", "Nimet", "Sarina", "Jean-Pierre", "Otto", "Jasmin", "Beata", "Sally", "Moana", "Lennard", "Tiago", "Ismail", "Francis", "Aurelia", "Bratislava", "Marek", "Shahin", "Helga", "Yusuf", "Zoe", "Auguste", "Mohamad", "Noah", "Justine", "Jochen", "Oliver", "Alexa", "Mirac", "Fritzi", "Lili", "Zofia", "Gerrit", "Mats", "Leonidas", "Selman", "Lenja", "Pierce", "Alice", "Malea", "Lamin", "Isa", "Jack", "Lucie", "Berk", "Roland", "Dan", "Max", "Malia", "Stella", "Larina", "Aslan", "Leilani", "Alexander", "Julien", "Carina", "Nino", "Christina", "Warwara", "Jannik", "Naomi", "Esmeralda", "Sofija", "Ayla", "Lion", "Larissa", "Alois", "Vera", "Alisa", "Idil", "Maya", "Feline", "Victoria", "Li", "Janara", "Veit", "Hatun", "Augustin", "Quentin", "Claudia", "Miran", "Erwin", "Memet", "Annika", "Loredana", "Angel", "Taha", "Ilias", "Erika", "Rolf", "Ivo", "Marcel", "Sima", "Artur", "Denny", "Dara", "Ella", "Oscar", "Rana", "Malik", "Emina", "Cilia", "Melina", "Malou", "Juliana", "Ayca", "Norbert", "Crispin", "Hugo", "Jonathan", "Anita", "Anthony", "Theresia", "Gregor", "Damla", "Hatice", "Luzie", "Valentin", "Gioia", "Mariam", "Steven", "Ann", "Rainer", "Pauline", "Casper", "Esma", "Tiara", "Ernesto", "Arjen", "Eduard", "Kolja", "Oleksandrivna", "Farnusch", "Atilla", "Polina", "Sinan", "Laureen", "Jamila", "Jari", "Hailey", "Yannick", "Jonna", "Ariane", "Rihana", "Edanur", "Yunus", "Alen", "Valentina", "Sude", "Leni", "Alexandre", "Floris", "Gero", "Estella", "Betty", "Michaela", "Christin", "Selinay", "Andreas", "Berat", "Asmin", "Dawid", "Iven", "Friederike", "Nida", "Leif", "Mahmoud", "Deborah", "Kaan", "Veronica", "Elischa", "Maren", "Almamy", "Salih", "Mirella", "Thorben", "Elijah", "Jette", "Abdussamed", "Kayra", "Sven", "Melek", "Dana", "Nikolas", "Roman", "Tyrese", "Dilan", "Ian", "Rania", "Sabine", "Kristina", "Lennja", "Miguel", "Dante", "Manolo", "Friedrich", "Irmgard", "Emilio", "Henrik", "Miranda", "Kiana", "Hannelore", "Josefine", "Yannis", "An", "Mitike", "Kenan", "Kirill", "Lilo", "Lars", "Karol", "Felipe", "Hajar", "Jara", "Mark", "Fritz", "Lorenz", "Aysu", "Nikola", "Gonca", "Elvin", "Michel", "Jamil", "Zehra", "Tessa", "Mara", "Samet", "Omar", "Hilde", "Lorena", "Dieter", "Pilar", "Ingrid", "Denis", "Selvi", "Kuldip", "Antonia", "Matti", "June", "Simon", "Eliah", "James", "Berkay", "Smilla", "Martin", "Paulina", "Heinz", "Moses", "Charlie", "Valerian", "Amy", "Elena", "Rudi", "Lejla", "Ensar", "Emine", "Katrin", "Rocco", "Lola", "Nia", "Liara", "Elvira", "Eslem", "Sunny", "Kim", "Derya", "Lewin", "Jerzy", "Juliane", "Alina", "Connor", "Ilyas", "Kiara", "Hannah", "Aleksandrovna", "Ashley", "Kiano", "Felicia", "Marie-Sophie", "Eleonore", "Furkan", "Dalia", "Elin", "Matheo", "Emely", "Mio", "Joy", "Stefania", "Leoni", "Mathea", "Concetta", "Alejandro", "Can", "Kaya", "Alyssa", "Prince", "Reyhan", "Onur", "Santino", "Royan", "Lorin", "Maikel", "Monique", "Kinga", "Tabitha", "Titus", "Madina", "Lenn", "May", "Nic", "Edda", "Joel", "Ramon", "Morten", "Danil", "Matteo", "Tyler", "Christel", "Isabelle", "Mir", "Bilal", "Levent", "Emre", "Nelson", "Melik", "Tatjana", "Noelle", "Anneke", "Leticia", "Zina", "Domenico", "Doruk", "Tom", "Helge", "Janik", "Ronja", "Marc", "Kingston", "Jaron", "Fatma", "Marten", "Jan", "Salma", "Jeremy", "Kalle", "Manjula", "Luigi", "Marie", "Leo", "Darya", "Darwin", "Jermaine", "Eleni", "Nikolaos", "Noemi", "Sejid", "Emanoela", "Emirhan", "Ivan", "Zaid", "Hana", "Timotheus", "Ida", "Adelina", "Willi", "Bastian", "Pierre", "Asya", "Rose", "Zeyneb", "Hiba", "Louisa", "Beni", "Murat", "Milad", "Iliana", "Talha", "Mustafa", "Noura", "Janina", "Semina", "Rosalie", "Mariella", "Heidi", "David", "Elif", "Alba", "Nika", "Robert", "Selina", "Paco", "Aleyna", "Romeo", "Franziska", "Liam", "Meryem", "Katharina", "Laurens", "Luna", "Audrey", "Mirela", "Fynn", "Benjamin", "Isabell", "Lex", "Violeta", "Amal", "Ayaz", "Hiranur", "Josefina", "Gereon", "Nando", "Alicia", "Saskia", "Ioannis", "Ari", "Danielle", "Volker", "Elian", "Jesse", "Anastasia", "Melih", "Eymen", "Yara", "Christiane", "Hermine", "Lena-Marie", "Yuma", "Marlin", "Jacob", "Josephine", "Lukas", "Hassan", "Johan", "Susanna", "Juna", "Felix", "Vedat", "Nikolaus", "Miya", "Zelal", "Sascha", "Charles", "Til", "Ferdinand", "Marlen", "Athena", "Sarah", "Hicham", "Livia", "Lucien", "Riccardo", "Solveig", "Ediz", "Elia", "Maryam", "Ben", "Hasan", "Vincent", "Khadija", "Fabrice", "Felicitas", "Andrea", "Elvan", "Adesuwa", "Viola", "Sebastiano", "Kristin", "Shirin", "Minou", "Mikail", "Baran", "Colin", "Christoph", "Maroua", "Ciara", "Nima", "Joseph", "Tao", "Hildegard", "Karolina", "Karla", "Liv", "Feyza", "Nana", "Junis", "Sonja", "Kerim", "Issa", "Evelina", "Harun", "Linn", "Lillien", "Isaac", "Helmut", "Benno", "Jupp", "Lennert", "Nujin", "Luis", "Aydan", "Leonhard", "Markus", "Denise", "Sue", "Thomas", "Musa", "Emrah", "Gina", "Julia", "Soumaya", "Alma", "Kai", "Henry", "Dilara", "Mathias", "Pascal", "Mariana", "Aurora", "Mick", "Ernst", "Minel", "Rudolf", "Abdul", "Ilyes", "Yannik", "Mohamed", "Cosima", "Ludwig", "Mahmod", "Peer", "Agnes", "Nursema", "Charlotte", "Margarita", "Raad", "Emilia", "Shayan", "Aylin", "Bettina", "Merit", "Timur", "Vitus", "Hans", "Mae", "Lene", "Wolf", "Belinay", "Adib", "Kian", "San", "Rosa", "Massimo", "Gizem", "Christine", "Imran", "Lenny", "Bent", "Philippe", "Anastasija", "Shirley", "Marianne", "Souhaila", "Yavuz", "Anton", "Luke", "Amelia", "Emi", "Gabriela", "Otis", "Ceylin", "Samuele", "Antoine", "Maeve", "Armina", "Alessandro", "Isabella", "Hope", "Muriel", "Eve", "Lea", "Edin", "Leonardo", "Armando", "Nicolas", "Janne", "Jolina", "Bengisu", "Michael", "Esad", "Liliane", "Martha", "Marco", "Mattes", "ogly", "Siri", "Aurelius", "Amalia", "Nathanael", "Nejat", "Gabriel", "Wilhelm", "Patricia", "Hella", "Tomasz", "Petra", "Mounir", "Klaus", "Alfred", "Timm", "Elfriede", "Yawa", "Bella", "Harold", "Paula", "Ada", "Emin", "Matea", "Ulrike", "Dennis", "Acelya", "Beyda", "Dion", "Luuk", "Haris", "Umut", "Laura", "Luana", "Muhammet", "Jordan", "Ana", "Daniele", "Emma", "Niels", "Paulo", "Monika", "Antonius", "Milo", "Thore", "Theodor", "Erva", "Jennifer", "Elisabeth", "Aras", "Frederik", "Vivian", "Laurenz", "Selma", "Elfida", "Milan", "Jorden", "Pepe", "Katarina", "Dinara", "Marcus", "Uwe", "Selin", "Malin", "Arman", "Sena", "Leah", "Mandy", "Leander", "Carsten", "Ece", "Arda", "Ela", "Irene", "Ilaria", "Natalia", "Kjell", "Waldemar", "Justin", "Maris", "Seymen", "Nehir", "Nick", "Suzan", "Rasmus", "Dilay", "Asad", "Jada", "Carmen", "Niclas", "Davin", "Alea", "Christopher", "Karim", "Danial", "Duhan", "Juliano", "Rahel", "Georgia", "Torsten", "Harald", "Filip", "Samia", "Mila", "Emily", "Talia", "Maleen", "Julius", "Tunahan", "Pearl", "Linus", "Nike", "Serena", "Phoebe", "Helin", "Berfin", "Cassian", "Mina", "Joost", "Tillmann", "Tina", "Emmanuel", "Raphael", "Chantel", "Josepha", "Diar", "Fee", "Bjarne", "Hamza", "Abush", "Enrico", "Apollonia", "Hagen", "Najib", "Elija", "Halil", "Jule", "Michelle", "Louise", "Mansi", "Yaren", "Conrad", "Norman", "Egemen", "Ben-Luca", "Kathleen", "Svenja", "George", "Carla", "Chinedu", "Emelie", "Shania", "Manuela", "Enes", "Dejan", "Regina", "Henri", "Marika", "Fabio", "Maxima", "Lara", "Lucas", "Dunia", "Nada", "Viktoria", "Lana", "Hazal", "Albert", "Mya", "Anes", "Nikita", "Efecan", "Nelly", "Luk", "Arthur", "Helene", "Youssef", "Mika", "Nicola", "Alex", "Vivien", "Esra", "Beray", "Ron", "Amelie", "Roxana", "Alena", "Sofie", "Osman", "Adama", "Faruk", "Miray", "Maxwell", "Toni", "Keyan", "Rita", "Ewan", "Sefa", "Zerda", "Hubert", "Victor", "Eray", "Lavinia", "Maksim", "Maila", "Sina", "Edgar", "Comfort", "Selenia", "Sandra", "Ariana", "Ersan", "Mirko", "Zoey", "Henriette", "Alessia", "Milla", "Nur", "Margarete", "Can-Luca", "Andre", "Amanda", "Jean", "Kerem", "Jamal", "Cansu", "Madhu", "Lia", "Elyesa", "Magdalena", "Dean", "Alia", "Mehdi", "Nils", "Lean", "Philine", "Ralitseva", "Gisela", "Mario", "Madlen", "Arne", "Roza", "Noel", "Evin", "Erin", "Franca", "Jasper", "Fabienne", "Marlene", "Qi", "Milou", "Alessio", "Dorothea", "Charline", "Eliza", "Milane", "Akif", "Emmi", "Wolfgang", "Marwin", "Bala", "Sean", "Arif", "Florin", "Celin", "Seval", "Ahmet", "Samuel", "Miro", "Lynn", "Emil", "Mercedes", "Nathalie", "Achim", "Konrad", "Aleksandar", "Nico", "Hadeel", "Marleen", "Doris", "Valeria", "Liah", "Carmelo", "Damian", "Savas", "Daniel", "Jamie", "Marit", "Katja", "Ravi", "Edith", "Clemens", "Ramazan", "Burak", "Dario", "Franz", "Leyla", "Jaden", "Lotta", "Nicole", "Severin", "Layla", "Kaspar", "Rebecca", "Clark", "Ajda", "Sanja", "Filippo", "Jonas", "Letizia", "Said", "Timo", "Matin", "Akin", "Quirin", "Marius", "Darius", "Mitkov", "Tiffany", "Nele", "Elliott", "Jacques", "Zeynep", "Bedirhan", "Jonah", "Lilou", "Etienne", "Kumar", "Veronika", "Sam", "Salim", "Timea", "Georg", "Liselotte", "Helen", "Dirk", "Luay", "Adam", "Alican", "Yana", "Sophia", "Tristan", "Eliana", "Ava", "Gianna", "Roberta", "Rayan", "Stephanie", "Bardia", "Emir", "Florentine", "Imane", "Lothar", "Hannes", "Lieselotte", "Yetunde", "Benedict", "Melvin", "Ruby", "Tobias", "Ege", "Kasimir", "Romy", "Ezgi", "Jusuf", "Domenik", "Elias", "Melody", "Azim", "Tuncay", "Hennes", "Reinhard", "Ole", "Cosmo", "Adol'fovna", "Arwen", "Naja", "Samira", "Frida", "Bennett", "Fenja", "Iryna", "Muhammad", "Gabrielle", "Holly", "Ruben", "Luisa", "Rio", "Elida", "Ayman", "Alexandru", "Rabea", "Frederic", "Kaur", "Yasmin", "Alin", "Inge", "Alara", "Abdelaziz", "Sofia", "Ilana", "Marissa", "William", "Orkun", "Emile", "Laetitia", "Abdullah", "Jeremias", "Nura", "Falk", "Elvis", "Doreen", "Madeleine", "Melda", "Saphira", "Colonia", "Su", "Melitta", "Freya", "Stephan", "Ngoc", "Melissa", "Ameer", "Shawn", "Margaretha", "Neela", "Yahya", "Lilith", "Aysel", "Jannet", "Jana", "Lin", "Mathilde", "Enno", "Mike", "Merle", "Ivana", "Till", "Eduardo", "Anna", "Amira", "Aleksander", "Karlo", "Brian", "Marietta", "Madea", "Lioba", "Louis", "Tanem", "Finn", "Franciszka", "Belma", "Wendelin", "Kimberly", "Joanna", "Aymen", "Helena", "Melin", "Nas", "Mame", "Tabea", "Zara", "Rositza", "Ilona", "Don", "Lorenzo", "Jonatan", "Ilayda", "Alfons", "Nikolai", "Mathis", "Erhard", "Gabriele", "Dustin", "Anas", "Teoman", "Nevia", "Nala", "Lydia", "Asel", "Maik", "Chiara", "Aileen", "Salvatore", "Lamija", "Felina", "Yasemin", "Anni", "Rafael", "Teresa", "Angelique", "Eysan", "Liliana", "Johannes", "Lisa", "Yassine", "Darin", "Nina", "Viviana", "Gino", "Hanna", "Iva", "Lou", "Kaja", "Tino", "Xavier", "Lore", "Caspar", "Leopold", "Serkan", "Yousif", "Milana", "Francesco", "Elisa", "Jim", "Gustav", "Constantin", "Giuseppe", "Leandra", "Esperanza", "Alisha", "Margareta", "Daniela", "Ayoub", "Nila", "Jane", "Dietmar", "Josef", "Melis", "Kubilay", "Rayyan", "Julian", "Julina", "Milano", "Niko", "Joan", "Pablo", "Romina", "Maysoun", "Antonella", "Christian", "Franka", "Chayenne", "Anjali", "Amin", "Latisha", "Mira", "Luan", "Rada", "Kurt", "Joyce", "Violetta", "Clara", "Elizan", "Grace", "Arina", "Jordi", "Konstantin", "Miles", "Noam", "Mael", "Karin", "Henning", "Zeren", "Stefan", "Maurice", "Darian", "Yeliz", "Lewis", "Nuka", "Darleen", "Beverly", "Karina", "Marla", "Jace", "Junior", "Roberto", "Raul", "Nicoleta", "Jolie", "Nepomuk", "Lilian", "Pelin", "Hendrik", "Lasse", "Frank", "Alexios", "Jost", "Antonio", "Marita", "Samantha", "Marian", "Tjark", "Singh", "Ina", "Ali", "Aaron", "Carolina", "Rustam", "Kevin", "Sevgi", "Canel", "Eloise", "Leon", "Paul", "Dimitrij", "Balthasar", "Madita", "Karoline", "Olga", "Felizitas", "Theresa", "Mercy", "Fanny", "Emilian", "Mary", "Thea", "Faris", "Vanessa", "Hubertus", "Marlon", "Ricardo", "Werner", "Lily", "Kevser", "Charlotta", "Nathan", "Kuba", "Joline", "Florence", "Isis", "Martina", "Juan", "Johann", "Samanta", "Jeanne", "Dietrich", "Alessandra", "Azra", "Carlos", "Mari", "Joana", "Lysander", "Oskar", "Steffen", "Francesca", "Jona", "Lucian", "Fabian", "Fatima", "Jerome", "Corvin", "Charleen", "Janine", "Elina", "Ifeoma", "Walter", "Hanno", "Richard", "Lian", "Taylor", "Danilo", "Nadja", "Zeliha", "Catharina", "Eser", "Elanur", "Flora", "Achilles", "Adonay", "Marilen", "Enna", "Jiyan", "Bejna", "Luc", "Nik", "Esther", "Lennon", "Julie", "Poyraz", "Taylan", "Leonard", "Aimee", "Judith", "Phileas", "Adrian", "Justus", "Younes", "Sontje", "Lenard", "Gloria", "Devin", "Tamina", "Johnny", "Leana", "Leandro", "Thalia", "Nuria", "Defne", "Owen", "Azad", "Kate", "Jens", "Philo", "Neele", "Aya", "Annette", "Serdar", "Medina", "Annabelle", "Klara", "Fine", "Matthias", "Nuri", "Derin", "Jessica", "Niklas", "Lennart", "Esila", "Caroline", "Lijan", "Miley", "Arvid", "Nicklas", "Bernhard", "Luka", "Theodora", "Talisha", "Piet", "Joshua", "Willem", "John", "Armin", "Brandon", "Timon", "Mattia", "Anne", "Melike", "Erdem", "Nilay", "Ulrich", "Emmy", "Hilal", "Linda", "Manfred", "Dominic", "Naz", "Lisa-Marie", "Nahla", "Semra", "Delia", "Laeticia", "Aaliyah", "Ekaterina", "Amadeus", "Halim", "Daria", "Melanie", "Minu", "Silas", "Dunja", "Elianna", "Mette", "Olivia", "Susan", "Tara", "Ilena", "Stvetanka", "Merve", "Marija", "Diana", "Gertrud", "Ibrahim", "Elsa", "Erich", "Malika", "Frieda", "Mert", "Viggo", "Soraya", "Magnus", "Finley", "Andrej", "Pheline", "Peter", "Maxim", "Batuhan", "Renate", "Giada", "Bruno", "Gian", "Jill", "Laurin", "August", "Conner", "Eric", "Selim", "Marisa", "Rashid", "Nuno", "Mete", "Lea-Sophie", "Vito" };

        string _antName;

        public string AntName => _antName;

        public AmeiseBasis() 
        {
            _antName = NameList[GameOptions.Random.Next(NameList.Length-1)];
        }

        StatusEnum _status = StatusEnum.WAIT;

        public StatusEnum Status => _status;

        public void Move()
        {
            _status = StatusEnum.MOVE;
        }

        public void Stop()
        {
            _status = StatusEnum.WAIT;
        }

        public virtual void Wait()
        {
            
        }

        public void Turn(int degrees)
        {
            
        }
    }
}
