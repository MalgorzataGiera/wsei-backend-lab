﻿using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class Quiz : IIdentity<int>
{
    public int Id { get; set; }

    public string Title { get; init; }

    public List<QuizItem> Items { get; set; }

    public Quiz(int id, string title, List<QuizItem> items)
    {
        Id = id;
        Items = items;
        Title = title;
    }
    public Quiz()
    {
    }

}