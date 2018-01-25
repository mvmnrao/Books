using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DomainObjects.Managers
{
    public class XmlToExamConvertor
    {
        public static Exam ConvertXmlToExam(string path)
        {
            Exam exam = new Exam();
            Question question = null;

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode examNode = doc.SelectSingleNode("Exam");

            exam.Title = (examNode.Attributes["title"] as XmlAttribute).Value;

            XmlNodeList nodeQuestions = doc.SelectNodes("Exam/Questions/Question");

            foreach (XmlNode nodeQuestion in nodeQuestions)
            {
                question = new Question();
                question.Text = (nodeQuestion.Attributes["text"] as XmlAttribute).Value;
                question.Point = Convert.ToDouble((nodeQuestion.Attributes["point"] as XmlAttribute).Value);

                XmlNodeList nodeChoices = nodeQuestion.SelectNodes("Choices/Choice");

                foreach (XmlNode nodeChoice in nodeChoices)
                {
                    Choice choice = new Choice();
                    choice.Text = (nodeChoice.Attributes["text"] as XmlAttribute).Value;
                    choice.IsCorrect = Convert.ToBoolean((nodeChoice.Attributes["isCorrect"] as XmlAttribute).Value);

                    question.AddChoice(choice);
                }

                exam.AddQuestion(question);
            }

            return exam;

        }
    }
}
