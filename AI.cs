using System;

public static class AI
{
    private SolidColorBrush red = new SolidColorBrush(System.Windows.Media.Color.FromRgb(249, 182, 182));

    public static int[] LowLevelAI(Button[] buttons)
    {
        int[] result = new int[2];
        List<Button> redButtonsList = new List<Button>();
        foreach(Button but in buttons)
        {
            if(but.Background == red)
            {
                redButtonsList.add(but);
            }

        }
    }
}
