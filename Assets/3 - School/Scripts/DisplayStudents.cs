using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStudents : MonoBehaviour
{
  int students = 0;
  TextMeshProUGUI StudentsText;
  void Start()
  {
    StudentsText = GetComponent<TextMeshProUGUI>();
    UpdateDisplay();
  }

  private void UpdateDisplay()
  {
    StudentsText.text = students.ToString("00");
  }

  public void AddStudent()
  {
    students += 1;
    UpdateDisplay();
  }

  public void RemoveStudent()
  {
    if (students >= 1)
    {
      students -= 1;
    }

    UpdateDisplay();
  }

  public int GetStudents()
  {
    return students;
  }

}
