using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExemples
{

    #region Path
    class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }

        public void Cd(string newPath)
        {
            List<string> stringArray = CurrentPath.Split('/').ToList();
            stringArray = stringArray.Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (newPath.Contains(".."))
            {
                string[] arraySplit = { "..", "/" };
                List<string> changeInDirectory = newPath.Split(arraySplit, StringSplitOptions.RemoveEmptyEntries).ToList();
                var countChangeDirectory = changeInDirectory.Count;
                foreach (var item in changeInDirectory)
                {
                    stringArray[stringArray.Count - countChangeDirectory] = item;
                    countChangeDirectory--;
                }
                var resultArray = new List<string>();
                foreach (var item in stringArray)
                {
                    resultArray.Add('/' + item);
                }
                CurrentPath = String.Join("", resultArray.ToArray());
            }else
            {

            }
        }
    }
    #endregion Path

    class Program
    {
        #region TrainComposition
        public class TrainComposition
        {
            List<int> arrayWagon = new List<int>();

            public void AttachWagonFromLeft(int wagonId)
            {
                arrayWagon.Insert(0, wagonId);
            }

            public void AttachWagonFromRight(int wagonId)
            {
                arrayWagon.Add(wagonId);
            }

            public int DetachWagonFromLeft()
            {
                var detachWagonLeft = arrayWagon[0];
                arrayWagon.Remove(detachWagonLeft);
                return detachWagonLeft;
            }

            public int DetachWagonFromRight()
            {
                var detachWagonRight = arrayWagon[arrayWagon.Count - 1];
                arrayWagon.Remove(detachWagonRight);
                return detachWagonRight;
            }

        }
        #endregion TrainComposition

        #region alertDao
        //alertDao сервис для отправки сообщений
        public interface IAlertDAO
        {
            Guid AddAlert(DateTime time);
            DateTime GetAlert(Guid id);
        }

        public class AlertService
        {
            //private readonly AlertDao storage = new AlertDao();
            private IAlertDAO storage;
            public AlertService(IAlertDAO alertDao)
            {
                storage = alertDao;
            }

            public Guid RaiseAlert()
            {
                return this.storage.AddAlert(DateTime.Now);
            }

            public DateTime GetAlertTime(Guid id)
            {
                return this.storage.GetAlert(id);
            }
        }

        public class AlertDao : IAlertDAO
        {
            private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

            public Guid AddAlert(DateTime time)
            {
                Guid id = Guid.NewGuid();
                this.alerts.Add(id, time);
                return id;
            }

            public DateTime GetAlert(Guid id)
            {
                return this.alerts[id];
            }


        }
        //alertDao
        #endregion alertDao

        #region palindrom
        /*palindrom*/
        public static bool IsPalindrome(string word)
        {
            word = word.ToLower();
            var replaceWord = ReverseString(word);
            string arrayA = "";
            string arrayB = "";
            foreach (var chart in word)
            {
                arrayA = arrayA + chart;
            }
            foreach (var chart in replaceWord)
            {
                arrayB = arrayB + chart;
            }


            if (arrayA == arrayB)
            {
                return true;
            }
            return false;
        }
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /*palindrom*/
        #endregion palindrom

        #region folders
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            string result = string.Empty;

            string[] xmlArray = xml.Split('>');
            foreach (var tag in xmlArray)
            {
                if (tag.Contains("<folder name=\"" + startingLetter))
                {
                    var wordTags = tag.Split('"');
                    foreach (var partWord in wordTags)
                    {
                        if (partWord.Contains(startingLetter))
                        {
                            result += (partWord) + ',';
                        }

                    }

                }
            }

            string[] newSplitArraySting = result.Split(',');

            var newArraySting = newSplitArraySting.Take(newSplitArraySting.Length - 1);


            return newArraySting;
        }
        #endregion foldername

        #region BinarySearchTree
        public static bool Contains(Node root, int value)
        {
            if (root.Value == value)
            {
                return true;
            }
            else
            {
                if (Program.Contains(root.Right, value))
                {
                    return true;
                }
                else
                {
                    if (Program.Contains(root.Left, value))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // || root.Left.Value == value
            }
        }
        #endregion

        #region TwoSum
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            Tuple<int, int> result;
            var Item1 = 0;
            var Item2 = 0;
            for (var i = 0; i < list.Count - 1; i++)
            {
                Item1 = list[i];
                for (var j = list.Count() - 1; j > 0; j--)
                {
                    Item2 = list[j];
                    if ((Item1 + Item2) == sum)
                    {
                        break;
                    }
                }
                if ((Item1 + Item2) == sum)
                {
                    break;
                }
            }
            if ((Item1 + Item2) == sum)
            {
                return result = new Tuple<int, int>(Item1, Item2);
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region Mergenames
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            var nameArray1 = names1.ToList();
            var nameArray2 = names2.ToList();

            List<string> result = nameArray1;
            foreach (var item in nameArray2)
            {
                result.Add(item);
            }


            for (var i = 0; i < result.Count() - 1; i++)
            {
                var count = 0;
                for (var j = result.Count() - 1; j > 0; j--)
                {
                    if (result[i] == result[j])
                    {
                        count++;
                        if (count > 1)
                        {
                            result.Remove(result[j]);
                        }

                    }
                }
            }
            return result.ToArray();
            //return result.Distinct().ToArray();
        }

        #endregion Mergenames

        #region SortedSearch
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            var i = 0;
            foreach (var item in sortedArray)
            {
                if (item < lessThan)
                {
                    i++;
                }
            }
            return i;
        }
        #endregion SortedSearch

        #region Grinch
        public static string GrinchAlgoritm(string inputString)
        {
            int magicNumber = Int32.Parse(inputString[0].ToString());
            var payLoad = "";
            //взял все кроме первого элемента
            for(var it = 1; it < inputString.Length; it++)
            {
                payLoad = payLoad + inputString[it];
            }
            //реверс строки
            payLoad = Program.ReverseString(payLoad);
            
            var alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var outputString = "";
            int elementIndex = 0;
            char elementChar;
            int currentSum;
            int i = payLoad.Count();
            int j = 0;
            while (i > 0)
            {
                
                    var rs = payLoad[j].ToString() + payLoad[j+1].ToString();
                    
                    int temp = Int32.Parse(rs);
                    if (temp < 33)
                    {
                        currentSum = temp;

                        elementIndex = currentSum - magicNumber;
                        elementChar = alphabet[elementIndex];
                        outputString = outputString + elementChar;
                        i=i-2;
                    }
                    else{
                        var temps = payLoad[j].ToString();
                        elementIndex = Int32.Parse(temps) - magicNumber;
                        elementChar = alphabet[elementIndex];
                        outputString = outputString + elementChar;
                        i--;
                    }
                    //тут надо брать первый символ а не последний
                   
                
                j=j+2;
                
            }
            return outputString;
        }
        
        #endregion Grinch

        static void Main(string[] args)
        {
            #region palindrom
            /*palindrom*/
            Console.WriteLine(Program.IsPalindrome("Deleveled"));
            #endregion palindrom
            #region TextInput
            /*TextInput*/
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Console.WriteLine(input.GetValue());
            /*TextInput*/
            #endregion TextInput
            #region folders
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
           "<folder name=\"c\">" +
               "<folder name=\"program files\">" +
                   "<folder name=\"uninstall information\" />" +
               "</folder>" +
               "<folder name=\"users\" />" +
           "</folder>";

            foreach (string name in Program.FolderNames(xml, 'u'))
                Console.WriteLine(name);
            #endregion folders
            #region BinarySearchTree
            Console.WriteLine("BinarySearchTree");
            Node n1 = new Node(1, null, null);
            Node n3 = new Node(3, null, null);
            Node n2 = new Node(2, n1, n3);
            Console.WriteLine(Contains(n2, 3));
            #endregion
            #region TwoSum
            Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            if (indices != null)
            {
                Console.WriteLine(indices.Item1 + " " + indices.Item2);
            }
            #endregion
            #region Mergenames
            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", Program.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
            #endregion Mergenames
            #region SongList
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");

            first.NextSong = second;
            second.NextSong = first;

            Console.WriteLine(first.IsRepeatingPlaylist());
            #endregion SongList
            #region Flags
            Console.WriteLine(Access.Writer.HasFlag(Access.Delete));
            Console.WriteLine(Access.Editor.HasFlag(Access.Comment));
            Console.WriteLine(Access.Owner.HasFlag(Access.Editor));
            #endregion Flags
            #region DecoratorStream
           /* byte[] message = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21 };
            using (MemoryStream stream = new MemoryStream())
            {
                using (DecoratorStream decoratorStream = new DecoratorStream(stream, "First line: "))
                {
                    decoratorStream.Write(message, 0, message.Length);
                    stream.Position = 0;
                    Console.WriteLine(new StreamReader(stream).ReadLine());  //should print "First line: Hello, world!"
                }
            }*/
            #endregion DecoratorStream
            #region SortedSearch
            Console.WriteLine(Program.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
            #endregion
            #region TrainComposition
            TrainComposition tree = new TrainComposition();
            tree.AttachWagonFromLeft(7);
            tree.AttachWagonFromLeft(13);
            Console.WriteLine(tree.DetachWagonFromRight()); // 7 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 13
            #endregion TrainComposition
            #region Path
            Path path = new Path("/a/b/c/d");   //  '/a/b/c/x'.
            path.Cd("../x/../k");
            Console.WriteLine(path.CurrentPath);
            #endregion Path
            #region GrinchAlgoritm
            var inpustring = "770627312802201"; // "52250315091"; //назара //442513151 кику //55071024170 виола


            Console.WriteLine("grinch " + GrinchAlgoritm(inpustring));
            #endregion GrinchAlgoritm
            Console.ReadKey();
        }


    }

    #region Flags
    /*
       Update and extend the enum so that it contains three new access flags:
       A Writer access flag that is made up of the Submit and Modify flags.
       An Editor access flag that is made up of the Delete, Publish and Comment flags.
       An Owner access that is made up of the Writer and Editor flags.
     */
    [Flags]
    public enum Access : byte
    {
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment =8,
        Modify = 16,
        Writer = Access.Submit | Access.Modify,
        Editor = Access.Delete | Access.Publish | Access.Comment,
        Owner = Access.Writer | Access.Editor,
    }


    #endregion Flags

    #region TextInput
    /*TextInput*/
    public class TextInput
    {
        public string result;
        public virtual void Add(char c)
        {
            result = result + c;
        }

        public string GetValue()
        {
            return result;
        }
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            int res;
            if (int.TryParse(c.ToString(), out res))
            {
                result = result + res.ToString();
            }

        }

    }
    /*TextInput*/
    #endregion TextInput

    #region BinarySearchTree
    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
    #endregion

    #region Pets


    /*
     * nformation about pets is kept in two separate tables:

    TABLE dogs
    id INTEGER NOT NULL PRIMARY KEY,
    name VARCHAR(50) NOT NULL

    TABLE cats
    id INTEGER NOT NULL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
    Write a query that select all distinct pet names.

    See the example case for more details.
      SELECT distinct name
       FROM   (SELECT name
        FROM   cats
        UNION ALL
        SELECT name
        FROM   dogs) AS t
    */
    #endregion #region Pets

    #region Accout 
    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }

        public Account(double overdraftLimit)
        {
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            this.Balance = 0;
        }

        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }



    #endregion Account

    #region SongList
    public class Song
    {
        private string name;
        public Song NextSong { get; set; }

        public Song(string name)
        {
            this.name = name;
        }

        public bool IsRepeatingPlaylist()
        {
            return (this.NextSong == null) ? false : true;
        }
    }
    #endregion SongList

    #region DecoratorStream
    /*DecoratorStream*/
    public class DecoratorStream : Stream
    {
        private Stream stream;
        private string prefix;

        public override bool CanSeek { get { return false; } }
        public override bool CanWrite { get { return true; } }
        public override long Length { get; }
        public override long Position { get; set; }
        public override bool CanRead { get { return false; } }

        public DecoratorStream(Stream stream, string prefix) : base()
        {
            this.stream = stream;
            this.prefix = prefix;
        }

        public override void SetLength(long length)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] bytes, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] bytes, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void Flush()
        {
            stream.Flush();
        }
        
    }
    /*DecoratorStream*/
    #endregion DecoratorStream
}