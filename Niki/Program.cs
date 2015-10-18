namespace Computers.UI
{
    using System;
    using System.Collections.Generic;

    public class Computers
    {
        private static Computer pc, laptop, server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var ram = new Rammstein(8 / 4);
                var videoCard = new HardDriver()
                {
                    IsMonochrome = false
                };

                pc = new Computer(
                    ComputerType.PC, 
                    new Cpu(
                        8 / 4, 
                        32, 
                        ram, 
                        videoCard), 
                    ram, 
                    new[] { new HardDriver(500, false, 0) }, 
                    videoCard, 
                    null);

                var serverRam = new Rammstein(8 * 4);
                var serverVideo = new HardDriver();
                server = new Computer(
                    ComputerType.SERVER, 
                    new Cpu(
                        8 / 2, 
                        32, 
                        serverRam, 
                        serverVideo),
                    serverRam,
                    new List<HardDriver>
                    {
                        new HardDriver(
                            0, 
                            true, 
                            2, 
                            new List<HardDriver>
                            {
                                new HardDriver(1000, false, 0),
                                new HardDriver(1000, false, 0)
                            })
                    },
                    serverVideo, 
                    null);
                {
                    var card = new HardDriver()
                    {
                        IsMonochrome = false
                    };

                    var ram1 = new Rammstein(8 / 2);
                    laptop = new Computer(
                        ComputerType.LAPTOP,
                        new Cpu(
                            8 / 4, 
                            64, 
                            ram1, 
                            card),
                        ram1,
                        new[] { new HardDriver(500, false, 0) },
                        card,
                        new LaptopBattery());
                }
            }
            else if (manufacturer == "Dell")
            {
                var ram = new Rammstein(8);
                var videoCard = new HardDriver()
                {
                    IsMonochrome = false
                };
                pc = new Computer(
                    ComputerType.PC, 
                    new Cpu(
                        8 / 2, 
                        64, 
                        ram, 
                        videoCard), 
                    ram, 
                    new[] { new HardDriver(1000, false, 0) }, 
                    videoCard, 
                    null);
                var ram1 = new Rammstein(8 * 8);
                var card = new HardDriver();
                server = new Computer(
                    ComputerType.SERVER,
                    new Cpu(
                        8, 
                        64, 
                        ram1, 
                        card),
                    ram1,
                    new List<HardDriver>
                    {
                        new HardDriver(
                            0, 
                            true, 
                            2, 
                            new List<HardDriver>
                            {
                                new HardDriver(2000, false, 0),
                                new HardDriver(2000, false, 0)
                            })
                        }, 
                    card, 
                    null);

                var ram2 = new Rammstein(8);
                var videoCard1 = new HardDriver()
                {
                    IsMonochrome = false
                };
                laptop = new Computer(
                    ComputerType.LAPTOP, 
                    new Cpu(
                        8 / 2, 
                        32, 
                        ram2, 
                        videoCard1),
                    ram2,
                    new[] { new HardDriver(1000, false, 0) },
                    videoCard1,
                    new LaptopBattery());
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            while (true)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    break;
                }

                if (c.StartsWith("Exit"))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (cp.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);

                if (cn == "Charge")
                {
                    laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    server.Process(ca);
                }
                else if (cn == "Play")
                {
                    pc.Play(ca);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}
