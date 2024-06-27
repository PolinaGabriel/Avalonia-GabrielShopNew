using System.Collections.Generic;

namespace GabrielShop
{
    public static class Assortiment
    {
        public static List<Product> products = new List<Product>() { //все товары
            new Product()
            {
                id = 0,
                source = "Asset/Image1.jpg",
                name = "Кот 1",
                cat = 1,
                descr = "Хороший кот, надо брать",
                man = "OOO 'Поставщик котов'",
                manId = 1,
                enable = 0,
                price = 10,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 1,
                name = "Не кот 1",
                cat = 2,
                descr = "Не кот, но тоже ничего",
                man = "OOO 'ААА'",
                manId = 2,
                enable = 20,
                price = 100,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 2,
                source = "Asset/Image3.jpg",
                name = "ААА 1",
                cat = 2,
                descr = "ббббббббббббббббббб",
                man = "Неизвестен",
                manId = 3,
                enable = 2500,
                price = 20,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 3,
                source = "Asset/Image1.jpg",
                name = "Кот 2",
                cat = 1,
                descr = "Хороший кот, надо брать",
                man = "OOO 'Поставщик котов'",
                manId = 1,
                enable = 5,
                price = 200,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 4,
                source = "Asset/Image2.jpg",
                name = "Не кот 2",
                cat = 2,
                descr = "Не кот, но тоже ничего",
                man = "OOO 'ААА'",
                manId = 2,
                enable = 0,
                price = 30,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 5,
                name = "ААА 2",
                cat = 2,
                descr = "ббббббббббббббббббб",
                man = "Неизвестен",
                manId = 3,
                enable = 40,
                price = 300,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 6,
                name = "Кот 3",
                cat = 1,
                descr = "Хороший кот, надо брать",
                man = "OOO 'Поставщик котов'",
                manId = 1,
                enable = 5,
                price = 40,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 7,
                source = "Asset/Image2.jpg",
                name = "Не кот 3",
                cat = 2,
                descr = "Не кот, но тоже ничего",
                man = "OOO 'ААА'",
                manId = 2,
                enable = 20,
                price = 400,
                quantity = 0,
                cost = 0
            },
            new Product()
            {
                id = 8,
                source = "Asset/Image3.jpg",
                name = "ААА 3",
                cat = 2,
                descr = "ббббббббббббббббббб",
                man = "Неизвестен",
                manId = 3,
                enable = 0,
                price = 50,
                quantity = 0,
                cost = 0
            }
        };

        public static List<Product> order = new List<Product>(); //заказ
    }
}