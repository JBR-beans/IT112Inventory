using System;
using System.Collections.Generic;

// Juliea Ritola
// IT112 
// NOTES: Notes the instructor should read
// BEHAVIORS NOT IMPLEMENTED AND WHY: Are there any parts of the assignment 
// you did not complete?

namespace Ritola_Inventory
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Shipper shipper = new Shipper();
			bool Running = true;

			int choice;
			while (Running)
			{
				Console.WriteLine("Choose from the following options:");
				Console.WriteLine("1. Add a Bicycle to the shipment");
				Console.WriteLine("2. Add a Lawn Mower to the shipment");
				Console.WriteLine("3. Add a Baseball Glove to the shipment");
				Console.WriteLine("4. Add Crackers to the shipment");
				Console.WriteLine("5. List Shipment Items");
				Console.WriteLine("6. Compute Shipping Charges");
				Console.WriteLine();

				Console.Write("Enter your choice (1-6): ");
				int.TryParse(Console.ReadLine(), out choice);
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						if (shipper.CountShipmentItems() == 10)
						{
							Console.Write("Max item limit reached!\n\n");
						}
						if (shipper.CountShipmentItems() < 10)
						{
							shipper.Add(new Bicycle());
							Console.Clear();
						}
						
						break;
					case 2:
						if (shipper.CountShipmentItems() == 10)
						{
							Console.Write("Max item limit reached!\n\n");
						}
						if (shipper.CountShipmentItems() < 10)
						{
							shipper.Add(new LawnMower());
							Console.Clear();
						}
						
						break;
					case 3:
						if (shipper.CountShipmentItems() == 10)
						{
							Console.Write("Max item limit reached!\n\n");
						}
						if (shipper.CountShipmentItems() < 10)
						{
						shipper.Add(new BaseballGlove());
						Console.Clear();
						}

						break;
					case 4:
						if (shipper.CountShipmentItems() == 10)
						{
							Console.Write("Max item limit reached!\n\n");
						}
						if (shipper.CountShipmentItems() < 10)
						{
						shipper.Add(new Crackers());
						Console.Clear();
						}

						break;
					case 5:
						shipper.ListShipmentItems();
						break;
					case 6:
						decimal totalCost = shipper.ComputeShippingCharges();
						Console.WriteLine($"Total shipping charges: ${totalCost}\n");
						Console.WriteLine("Press any key to exit the application.");
						Console.ReadLine();
						Running = false;
						break;
					default:
						Console.WriteLine("Invalid choice. Please try again.\n");
						break;
				}
			} 
		}
	}

	

	interface IShippable
	{
		decimal ShipCost { get; }
		string Product { get; }
	}

	class Bicycle : IShippable
	{
		public decimal ShipCost { get { return 9.50m; } }
		public string Product { get { return "Bicycle"; } }
	}

	class LawnMower : IShippable
	{
		public decimal ShipCost { get { return 24.00m; } }
		public string Product { get { return "Lawn Mower"; } }
	}

	class BaseballGlove : IShippable
	{
		public decimal ShipCost { get { return 3.23m; } }
		public string Product { get { return "Baseball Glove"; } }
	}

	class Crackers : IShippable
	{
		public decimal ShipCost { get { return 0.57m; } }
		public string Product { get { return "Crackers"; } }
	}

	class Shipper
	{
		private List<IShippable> shipmentItems;
		public Shipper()
		{
			shipmentItems = new List<IShippable>();
		}

		public void Add(IShippable item)
		{
			shipmentItems.Add(item);
			Console.WriteLine($"{item.Product} has been added.");
			Console.WriteLine("Press any key to return to the menu");
			Console.ReadKey();
		}

		public int CountShipmentItems()
		{
			int totalcount = 0;
			foreach (var group in shipmentItems.GroupBy(item => item.Product))
			{
				int count = group.Count();
				totalcount += count;
			}
			return totalcount;
		}
		public void ListShipmentItems()
		{
			Console.WriteLine("Shipment manifest:");
			foreach (var group in shipmentItems.GroupBy(item => item.Product))
			{
				int count = group.Count();
				string product = group.Key;
				if (count > 1 && product != "Crackers")
					product += "s";
				Console.WriteLine($"{count} {product}");
			}
			
			Console.WriteLine();
		}

		public decimal ComputeShippingCharges()
		{
			decimal totalCost = 0m;
			foreach (var item in shipmentItems)
			{
				totalCost += item.ShipCost;
			}
			return totalCost;
		}
	}
}