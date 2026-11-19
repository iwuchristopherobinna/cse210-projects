public class Comment
{
    public string _commenterName;
    public string _commentText;

    // Constructor to easily set values when creating a comment
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }
}