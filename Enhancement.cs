public class Enhancement{
    public int ticketID, cost;
    public string summary, status, priority, submitter, assigned, watching, software, reason, estimate;

    public Enhancement(int ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string software, int cost, string reason, string estimate){
        this.ticketID=ticketID;
        this.summary=summary;
        this.status=status;
        this.priority=priority;
        this.submitter=submitter;
        this.assigned=assigned;
        this.watching=watching;
        this.software=software;
        this.cost=cost;
        this.reason=reason;
        this.estimate=estimate;
    }
    public string returnString(){
        return ticketID+", "+summary+", "+status+", "+priority+", "+submitter+", "+assigned+", "+watching+", "+software+", "+cost+", "+reason+", "+estimate;
    }

}