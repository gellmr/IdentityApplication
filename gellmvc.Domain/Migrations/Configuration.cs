namespace gellmvc.Migrations
{
  using gellmvc.Domain.Concrete;
  using gellmvc.Domain.Entities;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      ContextKey = "gellmvc.Domain.Concrete.EFDbContext";
    }

    protected override void Seed(EFDbContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.

      IList<Product> products = new List<Product>();

      products.Add(new Product()
      {
        Name = "Metal Gear Motor",
        Description = "12V motor with a 100:1 metal gearbox",
        ImageUrl = "metalGearmotor.png",
        UnitPrice = 100.00M,
        CostFromSupplier = 75.00M,
        QuantityInStock = 190,
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Mini Photocell SEN-09088",
        Description = "A photoconductive cell. Resistance varies according to the amount of light it is exposed to.",
        ImageUrl = "photocell.jpeg",
        UnitPrice = 2.00M,
        CostFromSupplier = 1.00M,
        QuantityInStock = 201,
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "PCB Holder with Magnifying Glass",
        Description = "Magnifying Glass: 90mm",
        ImageUrl = "pcbHolderWithMag.jpg",
        UnitPrice = 15.00M,
        CostFromSupplier = 12.00M,
        QuantityInStock = 40,
        CreatedAt = System.DateTime.Now
      });

      products.Add(new Product()
      {
        Name = "Wire - 8 x 2m lengths",
        UnitPrice = 5.0M,
        CostFromSupplier = 2.5M,
        QuantityInStock = 30,
        Description = "Copper core: 0.12mm diameter.",
        ImageUrl = "wire.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Alligator to Alligator Cables",
        UnitPrice = 5.0M,
        CostFromSupplier = 4.00M,
        QuantityInStock = 15,
        Description = "Each pack contains two cables: one red and one black.",
        ImageUrl = "alligator.png",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Cat-6 cable: Patch Cable",
        UnitPrice = 2.5M,
        CostFromSupplier = 2.00M,
        QuantityInStock = 100,
        Description = "Up to 500 mhz. Uses 4 twisted pairs with PE divider.",
        ImageUrl = "cat-6_cable.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Cat-6 cable: 3 meters",
        UnitPrice = 3.5M,
        CostFromSupplier = 3.00M,
        QuantityInStock = 110,
        Description = "Up to 500 mhz. Uses 4 twisted pairs with PE divider.",
        ImageUrl = "cat-6_cable5feet.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "USB 2.0 Cable: A to B (3 meters)",
        UnitPrice = 5.0M,
        CostFromSupplier = 4.50M,
        QuantityInStock = 75,
        Description = "USB 2.0 Cable (A to B) 10 feet",
        ImageUrl = "usbCable.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Arduino UNO",
        UnitPrice = 32.50M,
        CostFromSupplier = 27.50M,
        QuantityInStock = 42,
        Description = "Arduino is a microcontroller used for prototyping. It has a USB port so you can connect to a PC and load programs. The Arduino platform is open source, and uses a simple IDE which can be be freely downloaded.",
        ImageUrl = "arduinoUNO.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Ethernet Pro DEV-10536",
        UnitPrice = 56.00M,
        CostFromSupplier = 50.00M,
        QuantityInStock = 20,
        Description = "Arduino Pro Microcontroller with Ethernet Shield",
        ImageUrl = "ethernet_pro.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "ARMmite Pro",
        UnitPrice = 35M,
        CostFromSupplier = 27.50M,
        QuantityInStock = 12,
        Description = "ARM7 CPU running at 60MHz. Has 32K of Flash memory. Uses an Arduino Pro footprint.",
        ImageUrl = "ARM7.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "PRT-09567 Bread Board",
        UnitPrice = 6.5M,
        CostFromSupplier = 5.00M,
        QuantityInStock = 40,
        Description = "Solderless Bread Board. Has 30 Columns and 10 Rows. Length: 83.5mm Width: 54.5mm Height: 8.5mm",
        ImageUrl = "breadboard.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Capacitor: Electrolytic 1000uF 35V 105C L/ESR",
        UnitPrice = 2M,
        CostFromSupplier = 1M,
        QuantityInStock = 350,
        Description = "Diameter: 16mm Length: 20mm Impedence: 0.035",
        ImageUrl = "CapacitorElectrolytic1000uF_35V_105C_LESR.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "270pF 50Volt Ceramic Capacitor",
        UnitPrice = 0.5M,
        CostFromSupplier = 0.25M,
        QuantityInStock = 200,
        Description = "Lead Spacing: 5mm  (Pack of 2)",
        ImageUrl = "270pF_50_VoltCeramicCapacitor.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "0.01uF/10nF 3kV Ceramic Capacitor",
        UnitPrice = 2.50M,
        CostFromSupplier = 2M,
        QuantityInStock = 140,
        Description = "High Voltage",
        ImageUrl = "3kVCeramicCapacitor.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "LED 5mm Red Waterclear",
        UnitPrice = 0.65M,
        CostFromSupplier = 0.45M,
        QuantityInStock = 120,
        Description = "",
        ImageUrl = "LED_redWaterClear.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "LED 5mm Red Diffuse",
        UnitPrice = 0.20M,
        CostFromSupplier = 0.10M,
        QuantityInStock = 2000,
        Description = "",
        ImageUrl = "LED_RedDiffuse.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "PN200 PNP Transistor",
        UnitPrice = 0.35M,
        CostFromSupplier = 0.22M,
        QuantityInStock = 340,
        Description = "A single PN200 PNP Transistor",
        ImageUrl = "transistor.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "74LS155 IC Unit",
        UnitPrice = 2.20M,
        CostFromSupplier = 1.45M,
        QuantityInStock = 320,
        Description = "Dual 1 of 4 Decoder / Multiplexer",
        ImageUrl = "dual_1to4_decoder.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "74LS138 IC Unit",
        UnitPrice = 1.45M,
        CostFromSupplier = 0.90M,
        QuantityInStock = 240,
        Description = "1 of 8 Decoder / Demultiplexer",
        ImageUrl = "1to8_demuxIC.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Thermistor: NTC 5mm Dia, 100 Ohm",
        UnitPrice = 1.35M,
        CostFromSupplier = 1.05M,
        QuantityInStock = 230,
        Description = "Made of ceramic material which changes resistance according to temperature. Very reliable.",
        ImageUrl = "thermistor.png",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Metal Film Resistor Pack - 300 pieces",
        UnitPrice = 14.95M,
        CostFromSupplier = 11.35M,
        QuantityInStock = 100,
        Description = "Five of virtually every resistance value from 10 Ohm to 1 Meg.",
        ImageUrl = "resistors300pk.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Carbon Film Resistor Pack - 300 pieces",
        UnitPrice = 6.95M,
        CostFromSupplier = 4.95M,
        QuantityInStock = 210,
        Description = "Five of virtually every resistance value from 1 Ohm to 10 Meg.",
        ImageUrl = "carbonResistorPack300.png",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "500 Ohm 24mm Potentiometer",
        UnitPrice = 2.25M,
        CostFromSupplier = 1.70M,
        QuantityInStock = 230,
        Description = "Full size - 24mm diameter. Power rating is 0.5W maximum.",
        ImageUrl = "pot.png",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "9T 4300KV Brushless Motor",
        UnitPrice = 49.39M,
        CostFromSupplier = 29.30M,
        QuantityInStock = 210,
        Description = "Dimensions: 3.175mm shaft diameter. 36mm body diameter. 50mm can length. 66mm total length. Weight: 170g",
        ImageUrl = "brushlessMotor.jpeg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Crimp Tool With Connectors",
        UnitPrice = 13.95M,
        CostFromSupplier = 9.45M,
        QuantityInStock = 30,
        Description = "Comes with 80 of the most popular automotive connectors.",
        ImageUrl = "crimper.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Temperature Controller Soldering Station",
        UnitPrice = 59.95M,
        CostFromSupplier = 72.30M,
        QuantityInStock = 45,
        Description = "Temperature range: 150-450 degrees Celsius. Power: 40W",
        ImageUrl = "solder.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "Lead-Free Solder",
        UnitPrice = 17.95M,
        CostFromSupplier = 12.30M,
        QuantityInStock = 40,
        Description = "200g Roll. Wire Diameter: 1mm Composition: (Tin: 99.3% Copper: 0.7%)",
        ImageUrl = "solderWire.jpg",
        CreatedAt = System.DateTime.Now
      });
      products.Add(new Product()
      {
        Name = "6 '' Long Noser Pliers",
        UnitPrice = 11.95M,
        CostFromSupplier = 7.50M,
        QuantityInStock = 30,
        Description = "With serrated jaws.",
        ImageUrl = "pliers.jpg",
        CreatedAt = System.DateTime.Now
      });

      context.Products.AddRange(products);
      base.Seed(context);
    }
  }
}
