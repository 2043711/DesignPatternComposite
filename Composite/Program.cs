using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Structurale
{


    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite(40, "Destiny 2");
            root.Add(new DLC(15, "Pay2Win"));
            root.Add(new DLC(12, "NewMonster"));
            DLC dlc1 = new DLC(20, "NewGuns");
            root.Add(dlc1);


            Console.WriteLine("\n" + root.getFacture());
            Console.WriteLine(root.getPrix() + "$");

            root.Remove(dlc1);


            Console.WriteLine("\n" + root.getFacture());
            Console.WriteLine(root.getPrix() + "$");
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    public abstract class Component
    {
        protected int prix;
        protected string article;
        // Constructor
        public Component(int prix, string article)
        {
            this.prix = prix;
            this.article = article;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract int getPrix();
        public abstract string getFacture();
    }
    /// <summary>
    /// The 'Composite' class
    /// </summary>
    public class Composite : Component
    {
        List<Component> children = new List<Component>();
        // Constructor
        public Composite(int prix, string article) : base(prix, article)
        {
        }
        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }
        public override int getPrix()
        {
            int prixTotal = prix;
            foreach (Component component in children)
            {
                prixTotal += component.getPrix();
            }
            return prixTotal;
        }

        public override string getFacture()
        {
            string facture = article;
            foreach (Component component in children)
            {
                facture += "\n--" + component.getFacture();
            }
            return facture;
        }
    }
    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    public class DLC : Component
    {
        // Constructor
        public DLC(int prix, string article) : base(prix, article)
        {
        }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override int getPrix()
        {
            return this.prix;
        }

        public override string getFacture()
        {
            return this.article;
        }
    }
}
