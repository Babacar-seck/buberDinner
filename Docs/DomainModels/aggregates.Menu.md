# Domain Models

## Menu

```csharp
class Menu 
{
    Menue Create();
    void addDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id" : "00000-00000-00000-00000",
    "name": "Yummy Menu",
    "description": "A menu with Yummy food",
    "averageRating" : 4.5,
    "section" : [
        {
            "id" : "00000-00000-00000-00000",
            "name": "Apetizers",
            "description": "Starters",
            "items" : [
                {
                    "id" : "00000-00000-00000-00000",
                    "name": "Fried Pickles",
                    "description": "Deep fried Pickles",
                    "price" : 5.99
                }
            ]
        }
    ],
    "createdDateTime" : "2022-11-14T00:00.0000000Z",
    "updatedDateTime" : "2022-11-14T00:00.0000000Z",
    "hostId" : "00000-00000-00000-00000",
    "dinnerIds" : [
        "00000-00000-00000-00000",
        "00000-00000-00000-00000"
    ],
    "menuReviewId" : [
        "00000-00000-00000-00000",
        "00000-00000-00000-00000"
    ]

```
