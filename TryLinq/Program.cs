namespace TryLinq;

class Program
{
    // todo : add 30 foods using english  
    static string[] foods = new string[]
    {
        "Apple",
        "Banana",
        "Carrot",
        "Donut",
        "Egg",
        "Fish",
        "Grapes",
        "Hamburger",
        "Ice Cream",
        "Juice",
        "Kale",
        "Lemon",
        "Meatball",
        "Noodle",
        "Omelette",
        "Pineapple",
        "Quiche",
        "Rice",
        "Sandwich",
        "Taco",
        "Udon",
        "Veggie Burger",
        "Watermelon",
        "Xiaolongbao",
        "Yogurt",
        "Zucchini"
    };

    static void displayFoodsContainA()
    {
        Console.WriteLine("displayFoods:List!");
        var Select = new List<string>();
        foreach (var f in foods)
        {
            if (f.Contains("a"))
            {
                Select.Add(f);
            }
        }

        foreach (var s in Select)
        {
            Console.WriteLine(s);
        }

        var Select2 = from f in foods where f.Contains("a") select f;
        Console.WriteLine("displayFoods:Lambda!");
        foreach (var s in Select2)
        {
            Console.WriteLine(s);
        }

        Console.ReadKey();
    }

    static void displayFoodsSortPrice()
    {
        List<Food> list = Food.GetList(foods);
        var Select = from f in list orderby f.Price, f.Name select f;
        Console.WriteLine("displayFoodsSortPrice:Lambda");
        foreach (var s in Select)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }
    }

    static void displayFoodsFilter10()
    {
        List<Food> list = Food.GetList(foods);
        var Select = from f in list
            where f.Price == 10
            orderby f.Price, f.Name
            select f;
        Console.WriteLine("displayFoodsFilter10:Lambda");
        foreach (var s in Select)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }

        var Select2 = list.Where(f => f.Price == 10).OrderBy(f => f.Price).ThenBy(f => f.Name).ToList();
        Console.WriteLine("displayFoodsFilter10:Lambda2");
        foreach (var s in Select2)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }
    }

    public static void displayFoodsExcet10()
    {
        List<Food> list = Food.GetList(foods);
        var selectexcept = list.Except(list.Where(f => f.Price == 10)).ToList();
        Console.WriteLine("displayFoodsExcept:Except");
        foreach (var s in selectexcept)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }

        var selectunion = selectexcept.Union(list.Where(f => f.Price == 10)).ToList();
        Console.WriteLine("displayFoodsExcept:Union");
        foreach (var s in selectunion)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }
    }

    public static void displayFoodsTakeAndSkip()
    {
        List<Food> list = Food.GetList(foods);
        var selectTake = list.Take(10).ToList();
        Console.WriteLine("displayFoodsTakeAndSkip:Take");
        foreach (var s in selectTake)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }

        var selectSkip = list.Skip(10).ToList();
        Console.WriteLine("displayFoodsTakeAndSkip:Skip");
        foreach (var s in selectSkip)
        {
            Console.WriteLine($"{s.Name} : {s.Price}");
        }
    }

    public static void displayFoodsGroupPrice()
    {
        List<Food> list = Food.GetList(foods);
        var selectGr = list.GroupBy(f => f.Price);
        Console.WriteLine("displayFoodsGroupPrice");
        foreach (var gr in selectGr)
        {
            Console.WriteLine($"{gr.Key} : {gr.Count()}");
            foreach (var food in gr)
            {
                Console.WriteLine($"{food.Name} : {food.Price}");
            }
        }
    }

    public static void displayFoodsJoinKind()
    {
        List<Food> list = Food.GetList(foods);
        List<FoodKind> listKind = FoodKind.GetList();
        // TODO : join list and listKind with Name using linq and print
        Console.WriteLine("displayFoodsJoinKind");
        var joinedList = from f in list
            join fk in listKind on f.Name equals fk.Name
            select new { FoodName = f.Name, FoodPrice = f.Price, FoodKind = fk.Kind };

        foreach (var item in joinedList)
        {
            Console.WriteLine($"Name: {item.FoodName}, Price: {item.FoodPrice}, Kind: {item.FoodKind}");
        }
    } 
    static void Main(string[] args)
    {
        // displayFoodsContainA();
        // displayFoodsSortPrice();
        // displayFoodsFilter10();
        // displayFoodsExcet10();
        // displayFoodsTakeAndSkip();
        //displayFoodsGroupPrice();
        displayFoodsJoinKind();
        //Console.WriteLine("Hello, World!");
    }
}

class Food
{
    public string Name { get; set; }
    public int Price { get; set; }

    public static List<Food> GetList(string[] foods)
    {
        int[] prices = new int[] { 10, 20, 30, 40 };
        var list = new List<Food>();
        int i = 0;
        foreach (var f in foods)
        {
            list.Add(new Food { Name = f, Price = prices[i++ % 4] });
        }

        return list;
    }
}

class FoodKind
{
    public string Name { get; set; }
    public int Kind { get; set; } // 0:Vegetable, 1:Meat , 2:Fruit

    public static int GetFoodKind(string foodName)
    {
        string[] fruits = { "Apple", "Banana", "Grapes", "Lemon", "Pineapple", "Watermelon" };
        string[] vegetables = { "Carrot", "Kale", "Zucchini" };
        string[] meats = { "Egg", "Fish", "Hamburger", "Meatball", "Sandwich", "Taco", "Veggie Burger", "Xiaolongbao" };

        if (fruits.Contains(foodName))
            return 2; // Fruit
        else if (vegetables.Contains(foodName))
            return 0; // Vegetable
        else if (meats.Contains(foodName))
            return 1; // Meat
        else
            return -1; // Unknown
    }

    public static List<FoodKind> GetList()
    {
        // todo : generate  foods kind into List<FoodKind> using english

        string[] foods = new string[]
        {
            "Apple",
            "Banana",
            "Carrot",
            "Donut",
            "Egg",
            "Fish",
            "Grapes",
            "Hamburger",
            "Ice Cream",
            "Juice",
            "Kale",
            "Lemon",
            "Meatball",
            "Noodle",
            "Omelette",
            "Pineapple",
            "Quiche",
            "Rice",
            "Sandwich",
            "Taco",
            "Udon",
            "Veggie Burger",
            "Watermelon",
            "Xiaolongbao",
            "Yogurt",
            "Zucchini"
        };

        var list = foods.Select(f => new FoodKind
        {
            Name = f,
            Kind = GetFoodKind(f)
        }).ToList();

        // 且用 var fk = new FoodKind() ; fk.Name = "Apple"; fk.Kind = "2"; list.add(fk);
        // 需要翻譯 food 然後辨別 food 的 kind 在 add 進 list
        return list;
    }
}