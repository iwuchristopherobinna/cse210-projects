using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Tutorial for Beginners", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "This video cleared up classes for me!"));
        video1.AddComment(new Comment("Bob", "Great pacing, thank you."));
        video1.AddComment(new Comment("Charlie", "Could you do a follow-up on inheritance?"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Productivity Tips", "StudyStream", 450);
        video2.AddComment(new Comment("Dave", "Tip #4 changed my entire daily routine."));
        video2.AddComment(new Comment("Emma", "Subscribed! Love your content."));
        video2.AddComment(new Comment("Frank", "Very practical advice."));
        videos.Add(video2);

        Video video3 = new Video("Lo-Fi Hip Hop Beats - Relaxing Music", "ChillHop Radio", 3600);
        video3.AddComment(new Comment("Grace", "Listening to this while coding right now."));
        video3.AddComment(new Comment("Heidi", "This stream has gotten me through college finals."));
        video3.AddComment(new Comment("Ivan", "Absolute classic playlist."));
        videos.Add(video3);

        Video video4 = new Video("Easy 15-Minute Home Workout", "FitnessBliss", 900);
        video4.AddComment(new Comment("Judy", "Oof, that was harder than it looks!"));
        video4.AddComment(new Comment("Kevin", "Adding this to my morning routine."));
        video4.AddComment(new Comment("Laura", "Thanks for keeping it beginner-friendly."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"--------------------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  - {comment._commenterName}: \"{comment._commentText}\"");
            }
            Console.WriteLine();
        }
    }
}