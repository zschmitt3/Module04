public class Ticket{
    public int ticketID;
    public string summary, status, priority, submitter, assigned, watching;

    public Ticket(int ticketID, string summary, string status, string priority, string submitter, string assigned, string watching){
        this.ticketID=ticketID;
        this.summary=summary;
        this.status=status;
        this.priority=priority;
        this.submitter=submitter;
        this.assigned=assigned;
        this.watching=watching;
    }
    public string returnString(){
        return ticketID+", "+summary+", "+status+", "+priority+", "+submitter+", "+assigned+", "+watching;
    }

}