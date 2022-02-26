namespace KulaLearnMVC.Models;

public class Course
{
    public string? ID { get; set; }
    public string? collectionID {get;set;}
    public string? title{get;set;}
    public string? shortDescription{get;set;}
    public string? imageUrl {get;set;}
    public int createdAt{get;set;}
    public string? uploader{get;set;}
    public Publish published{get;set;}
    public Visible visibility{get;set;}
}
public enum Visible{
    Private,
    Public
}
public enum Publish{
    Now,
    Later
}