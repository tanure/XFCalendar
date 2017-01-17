using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tanure.CalendarPOC.Models;

namespace Tanure.CalendarPOC.Test
{
    [TestClass]
    public class CalendarModelTest
    {
        [TestMethod]
        public void Create_Calendar()
        {
            // Arrange
            DateTime currentDate = DateTime.Now;

            // Act
            CalendarModel calendar = new CalendarModel(currentDate);

            // Assert
            Assert.AreEqual(calendar.CurrentMonth, currentDate.Month);

            Assert.AreEqual(calendar.CurrentYear, currentDate.Year);
        }


        [TestMethod]
        public void Has_No_Selected_Dates()
        {
            // Arrange
            DateTime currentDate = DateTime.Now;

            // Act
            CalendarModel calendar = new CalendarModel(currentDate);

            bool selected = false;

            DayModel[,] currentCalendar = calendar.CurrentCalendar;

            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for (int j = 0; j < currentCalendar.GetLength(1); j++)
                {
                    if (currentCalendar[i, j] != null && currentCalendar[i, j].Selected)
                    {
                        selected = true;
                        break;
                    }
                }
            }

            // Assert
            Assert.AreEqual(false, selected);

        }

        [TestMethod]
        public void Has_One_Selected_Date()
        {
            // Arrange
            DateTime currentDate = DateTime.Now;

            // Act
            CalendarModel calendar = new CalendarModel(currentDate);

            int selected = 0;
            bool foundItem = false;
            DayModel[,] currentCalendar = calendar.CurrentCalendar;

            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for (int j = 0; j < currentCalendar.GetLength(1); j++)
                {
                    if (currentCalendar[i, j] != null)
                    {
                        currentCalendar[i, j].Selected = true;
                        foundItem = true;
                        break;
                    }
                }
                if (foundItem)
                    break;
            }


            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for (int j = 0; j < currentCalendar.GetLength(1); j++)
                {
                    if (currentCalendar[i, j] != null && currentCalendar[i, j].Selected)
                    {
                        selected++;
                    }
                }
            }

            // Assert
            Assert.AreEqual(1, selected);
        }

        [TestMethod]
        public void Select_Current_Days()
        {
            // Arrange
            DateTime currentDate = DateTime.Now;

            // Act
            CalendarModel calendar = new CalendarModel(currentDate);

            DayModel selected = null;

            DayModel[,] currentCalendar = calendar.CurrentCalendar;

            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for (int j = 0; j < currentCalendar.GetLength(1); j++)
                {
                    if (currentCalendar[i, j] != null && currentCalendar[i, j].Date.Date == currentDate.Date)
                    {
                        currentCalendar[i, j].Selected = true;
                        break;
                    }
                }
            }


            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for (int j = 0; j < currentCalendar.GetLength(1); j++)
                {
                    if (currentCalendar[i, j] != null && currentCalendar[i, j].Selected)
                    {
                        selected = currentCalendar[i, j];
                    }
                }
            }

            // Assert
            Assert.AreEqual(currentDate.Date, selected.Date.Date);
        }
    }
}
