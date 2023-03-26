public class Task{
    public int ticketID;
    public string summary, status, priority, submitter, assigned, watching, projectName, dueDate;

    public Task(int ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate){
        this.ticketID=ticketID;
        this.summary=summary;
        this.status=status;
        this.priority=priority;
        this.submitter=submitter;
        this.assigned=assigned;
        this.watching=watching;
        this.projectName=projectName;
        this.dueDate=dueDate;
    }
    public string returnString(){
        return ticketID+", "+summary+", "+status+", "+priority+", "+submitter+", "+assigned+", "+watching+", "+projectName+", "+dueDate;
    }

}