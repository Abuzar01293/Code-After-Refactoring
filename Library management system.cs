using System;
using System.Collections.Generic;

// Abstract class for media items
public abstract class MediaItem
{
    public int ItemId { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }

    public MediaItem(int itemId, string title)
    {
        ItemId = itemId;
        Title = title;
        IsAvailable = true;
    }

    // Abstract method for checking out an item
    public abstract void CheckOut();

    // Abstract method for returning an item
    public abstract void Return();
}

// Book class that inherits from MediaItem
public class Book : MediaItem
{
    public string Author { get; set; }

    public Book(int itemId, string title, string author) : base(itemId, title)
    {
        Author = author;
    }

    public override void CheckOut()
    {
        if (IsAvailable)
        {
            Console.WriteLine("Book checked out successfully.");
            IsAvailable = false;
        }
        else
        {
            Console.WriteLine("Book is not available.");
        }
    }

    public override void Return()
    {
        if (!IsAvailable)
        {
            Console.WriteLine("Book returned successfully.");
            IsAvailable = true;
        }
        else
        {
            Console.WriteLine("Book is already available.");
        }
    }
}

// DVD class that inherits from MediaItem
public class DVD : MediaItem
{
    public int RunTime { get; set; }

    public DVD(int itemId, string title, int runTime) : base(itemId, title)
    {
        RunTime = runTime;
    }

    public override void CheckOut()
    {
        if (IsAvailable)
        {
            Console.WriteLine("DVD checked out successfully.");
            IsAvailable = false;
        }
        else
        {
            Console.WriteLine("DVD is not available.");
        }
    }

    public override void Return()
    {
        if (!IsAvailable)
        {
            Console.WriteLine("DVD returned successfully.");
            IsAvailable = true;
        }
        else
        {
            Console.WriteLine("DVD is already available.");
        }
    }
}

// Library class that manages the media items
public class Library
{
    private List<MediaItem> mediaItems = new List<MediaItem>();

    // Method to add a media item to the library
    public void AddMediaItem(MediaItem mediaItem)
    {
        mediaItems.Add(mediaItem);
        Console.WriteLine("Media item added to the library.");
    }

    // Method to remove a media item from the library
    public void RemoveMediaItem(MediaItem mediaItem)
    {
        if (mediaItems.Contains(mediaItem))
        {
            mediaItems.Remove(mediaItem);
            Console.WriteLine("Media item removed from the library.");
        }
        else
        {
            Console.WriteLine("Media item not found in the library.");
        }
    }

    // Method to check out a media item
    public void CheckOutMediaItem(int itemId)
    {
        MediaItem mediaItem = mediaItems.Find(item => item.ItemId == itemId);
        if (mediaItem != null)
        {
            mediaItem.CheckOut();
        }
        else
        {
            Console.WriteLine("Media item not found in the library.");
        }
    }

    // Method to return a media item
    public void ReturnMediaItem(int itemId)
    {
        MediaItem mediaItem = mediaItems.Find(item => item.ItemId == itemId);
        if (mediaItem != null)
        {
            mediaItem.Return();
        }
        else
