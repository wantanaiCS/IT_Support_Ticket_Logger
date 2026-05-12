namespace IT_Ticket_Logger
{
    class Program
    {
        // สร้าง manager ครั้งเดียว ใช้ตลอดโปรแกรม
        static TicketManager manager = new TicketManager();

        static void Main(string[] args)
        {
            Console.WriteLine("=== IT Support Ticket Logger ===");

            bool running = true;
            while (running)
            {
                ShowMenu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": CreateTicket(); break;
                    case "2": ShowAllTickets(); break;
                    case "3": UpdateTicketStatus(); break;
                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Create new ticket");
            Console.WriteLine("2. View all tickets");
            Console.WriteLine("3. Update ticket status");
            Console.WriteLine("4. Exit");
            Console.Write("Select: ");
        }

        static void CreateTicket()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            var description = Console.ReadLine() ?? "";

            var ticket = manager.AddTicket(title, description);
            Console.WriteLine($"Ticket #{ticket.Id} created!");
        }

        static void ShowAllTickets()
        {
            var tickets = manager.GetAllTickets();

            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            Console.WriteLine($"\n--- Tickets ({tickets.Count} total) ---");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"[#{ticket.Id}] {ticket.Title}");
                Console.WriteLine($"    Status : {ticket.Status}");
                Console.WriteLine($"    Created: {ticket.CreatedAt:dd/MM/yyyy HH:mm}");
                Console.WriteLine($"    Detail : {ticket.Description}");
            }
        }

        static void UpdateTicketStatus()
        {
            Console.Write("Enter Ticket ID: ");

            // TryParse = แปลง string เป็น int อย่างปลอดภัย ไม่ crash ถ้าพิมพ์ผิด
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.WriteLine("1. Open  2. InProgress  3. Resolved  4. Closed");
            Console.Write("Select: ");

            // switch expression = เขียนสั้นกว่า switch statement ปกติ
            TicketStatus newStatus = Console.ReadLine() switch
            {
                "1" => TicketStatus.Open,
                "2" => TicketStatus.InProgress,
                "3" => TicketStatus.Resolved,
                "4" => TicketStatus.Closed,
                _ => TicketStatus.Open
            };

            bool success = manager.UpdateStatus(id, newStatus);
            Console.WriteLine(success
                ? $"Ticket #{id} updated to {newStatus}"
                : $"Ticket #{id} not found.");
        }
    }
}