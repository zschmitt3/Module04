using System.IO;

string header = "TicketID, Summary, Status, Priority, Submitter, Assigned, Watching";

List<Ticket> ticketList = new List<Ticket>();
Ticket newTicket = new Ticket(1, "This is a bug ticket", "Open", "High", "Drew Kjell", "Jane Doe", "Drew Kjell|John Smith|Bill Jones");
ticketList.Add(newTicket);
//string entry "1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones";

StreamWriter sw = new StreamWriter("Tickets.csv", append: true);
sw.WriteLine(header);
sw.WriteLine(ticketList[1].returnString());
sw.Close();
