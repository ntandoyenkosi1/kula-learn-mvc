namespace KulaMVC.Models;

public class Course
{
    public string? ID { get; set; }
    public string? CollectionID { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? ImageUrl { get; set; }
    public int CreatedAt { get; set; }
    public string? Uploader { get; set; }
    public Publish published { get; set; }
    public Visible visibility { get; set; }
}
public enum Visible
{
    Private,
    Public
}
public enum Publish
{
    Now,
    Later
}