﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalkingStumpShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ImageFileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageFileName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "CreationDate", "ImageFileName", "Title" },
                values: new object[,]
                {
                    { 1L, "Мастерская 'Говорящий Пень' рада представить свою последнюю коллекцию уникальных столов, изготовленных с любовью и профессионализмом. Каждый стол - это настоящее произведение искусства, созданное из натурального дерева и эпоксидной смолы. Наши мастера вложили всю свою страсть и талант в каждый деталь, чтобы создать функциональные и впечатляющие предметы мебели, которые украсят ваш интерьер. Погрузитесь в мир природной красоты и изысканного дизайна с новой коллекцией столов 'Говорящий Пень'.", new DateTime(2023, 11, 7, 18, 14, 59, 174, DateTimeKind.Utc).AddTicks(9074), "tables-collection.png", "Новое творческое вдохновение: Говорящий Пень представляет уникальные столы из дерева и эпоксидной смолы!" },
                    { 2L, "С наступлением праздничного сезона мы рады представить вам нашу новую коллекцию эксклюзивных подарков ручной работы. Каждое изделие создано с заботой и вниманием к деталям нашими опытными мастерами. Вы найдете у нас подарки для всех случаев: от деревянных часов до восхитительных ваз и деревянных фигурок. Подарите вашим близким что-то особенное и уникальное в этот праздничный сезон!", new DateTime(2023, 11, 7, 18, 14, 59, 174, DateTimeKind.Utc).AddTicks(9078), "figure-collection.png", "Эксклюзивные подарки: Говорящий Пень представляет коллекцию деревянных изделий ручной работы" },
                    { 3L, "Мы рады объявить о запуске наших мастер-классов для всех любителей ручной работы и творчества! Присоединяйтесь к нам, чтобы научиться создавать удивительные изделия из дерева и эпоксидной смолы под руководством опытных мастеров. Эти мастер-классы предоставят вам уникальную возможность погрузиться в мир деревянного искусства и научиться создавать собственные шедевры. Следите за нашими объявлениями для получения дополнительной информации о датах и регистрации!", new DateTime(2023, 11, 7, 18, 14, 59, 174, DateTimeKind.Utc).AddTicks(9081), "master-class.png", "Мастер-классы от Говорящего Пня: научитесь создавать собственные шедевры из дерева и эпоксидной смолы!" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageFileName", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Этот набор разделочных досок идеален для подготовки пищи с удовольствием. Каждая доска обладает уникальным дизайном, который придает вашей кухне особый шарм. Идеально подходит для настольных приготовлений и подачи блюд. Сделайте свою кухню еще более стильной и функциональной.", "cutting-board-cats.jpg", "Набор разделочных досок", 1299m },
                    { 2L, "Этот кулон с цветком изготовлен с любовью и вниманием к деталям. Он станет великолепным подарком для вашей любимой. Уникальный дизайн и качественные материалы делают этот кулон украшением, которое будет радовать вас долгое время.", "epoxy-pendant.jpg", "Кулон с цветком", 1599m },
                    { 3L, "Это кольцо из эпоксидной смолы – это искусство на вашем пальце. Уникальный дизайн и качественное исполнение делают его прекрасным аксессуаром для вашего образа. Подчеркните свою индивидуальность с этим кольцом.", "epoxy-ring.jpg", "Кольцо из эпоксидной смолы", 599m },
                    { 4L, "Эта ваза 'Всплеск' – это настоящее произведение искусства. Изготовлена из эпоксидной смолы, она прекрасно дополнит интерьер вашего дома. Уникальный дизайн делает ее идеальным элементом декора и подарком.", "epoxy-vase.jpg", "Ваза 'Всплеск'", 4499m },
                    { 5L, "Этот набор статуэток из дерева вдохновлен древней мифологией. Каждая статуэтка сделана с большой любовью и вниманием к деталям. Он станет прекрасным украшением вашего дома и уникальным подарком для коллекционеров.", "idol-set.jpg", "Набор статуэток из дерева", 2199m },
                    { 6L, "Эта статуэтка 'Перун' изготовлена из дерева с особым вниманием к деталям. Она символизирует мощь и силу. Поместите эту статуэтку в свой дом, чтобы придать ему дополнительную атмосферу и символизировать свои убеждения.", "wooden-perun-idol.jpg", "Статуэтка 'Перун'", 1599m },
                    { 7L, "Эта статуэтка 'Воин' изготовлена из дерева и символизирует силу и защиту. Ее уникальный дизайн и качественные материалы делают ее идеальным подарком для любителей истории и мифологии.", "wooden-perun-idol-1.jpg", "Статуэтка 'Воин'", 1899m },
                    { 8L, "Эти деревянные часы 'Волны' принесут нотку морской атмосферы в ваш дом. Их уникальный дизайн и тщательная работа над деталями делают их идеальными как функциональным элементом интерьера и подарком для любителей моря.", "wooden-clock-waves.jpg", "Часы 'Волны'", 3099m },
                    { 9L, "Картина 'Абстракция' – это произведение современного искусства. Ее яркие цвета и абстрактный дизайн могут стать украшением вашей стены. Она поднимет настроение и добавит креативности в ваш дом.", "picture.jpg", "Картина 'Абстракция'", 13999m },
                    { 10L, "Эти деревянные часы представляют собой идеальное сочетание функциональности и элегантного дизайна. Они прекрасно впишутся в любой интерьер и помогут вам следить за временем с толком.", "wooden-clock.jpg", "Деревянные часы", 2299m },
                    { 11L, "Эти деревянные часы со смолой являются настоящим произведением искусства. Их уникальный дизайн и комбинация дерева с эпоксидной смолой делают их прекрасным дополнением к вашему интерьеру и удивительным подарком для близких.", "wooden-clock-epoxy.jpg", "Деревянные часы со смолой", 2899m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
