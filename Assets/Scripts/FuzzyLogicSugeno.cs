using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FuzzyLogicSugeno: MonoBehaviour
{
    public Timer theTime;
    public QuizManager quizManager;
    public Text MyGrade;
    public string ScoreGrade;
    public void Update()
    {

        double TotalSoalTerjawab = Convert.ToDouble(quizManager.UpdateQuestionTotal());
        double TotalJawabBenar = quizManager.score;
        double WaktuTersisa = Convert.ToDouble(theTime.countdownTime);

        /*
        double TotalSoalTerjawab = 18;
        double TotalJawabBenar = 13;
        double WaktuTersisa = 375; */

        // Fuzzification
        double[] membershipA = FuzzifyA(TotalSoalTerjawab);
        double[] membershipB = FuzzifyB(TotalJawabBenar);
        double[] membershipC = FuzzifyC(WaktuTersisa);

        double ScoreC = 1;
        double ScoreB = 2;
        double ScoreA = 3;

        double result = RuleEvaluation(membershipA, membershipB, membershipC, ScoreC, ScoreB, ScoreA);

        ScoreGrade = ResultScore(result);

        MyGrade.text = ScoreGrade;
        Debug.Log($"Hasil Evaluasi Aturan: {ScoreGrade}");
        Debug.Log($"Hasil Evaluasi Aturan: {result}");

        Debug.Log($"Total Soal = {TotalSoalTerjawab}, Benar = {TotalJawabBenar}, Waktu = {WaktuTersisa}");
    }

    public void ShowGrade() {    }

    //Kalkulasi Total Soal Terjawab
    public double[] FuzzifyA(double input)
    {
        return new double[]
        {
            KurvaBahuKiri(input, 0, 7),             // Hampir Tidak Terjawab
            KurvaSegitiga(input, 6, 10, 14),        // Beberapa Terjawab
            KurvaBahuKanan(input, 13, 20)           // Hampir Terjawab Semua
        };
    }

    //Kalkulasi Total Jawaban Benar
    public double[] FuzzifyB(double input)
    {
        return new double[]
        {
            KurvaBahuKiri(input, 0, 7),         // Sangat Kurang
            KurvaSegitiga(input, 6, 10.5, 15),  // Normal
            KurvaBahuKanan(input, 14, 20)       // Sangat Baik
        };
    }

    //Kalkulasi Waktu Tersisa
    public double[] FuzzifyC(double input)
    {
        return new double[]
        {
            KurvaBahuKiri(input, 0, 200),           // Lambat
            KurvaSegitiga(input, 150, 275, 400),    // Normal
            KurvaBahuKanan(input, 350, 600)         // Cepat
        };
    }

    //Output berupa penilaian yang diperoleh jika RuleEvaluation telah dikalkulasi
    public string ResultScore(double input) {
        if(input > 2 && input <= 3) return "A";
        if(input > 1 && input <= 2) return "B";
        return "C";
    }


    public double KurvaSegitiga(double x, double a, double b, double c) //Kurva Segitiga
    {
        if (x > a && x < b) return (x - a) / (b - a);
        if (x > b && x < c) return (c - x) / (c - b);
        return 0;
    }

    public double KurvaBahuKiri(double x, double a, double b)  //Kurva Bahu Kiri
    {
        if (x <= a) return 1;
        if (x >= a && x <= b) return (b - x) / (b - a);
        return 0;
    }

    public double KurvaBahuKanan(double x, double a, double b)  //Kurva Bahu Kanan
    {
        if (x <= a) return 0;
        if (x >= a && x <= b) return (x - a) / (b - a);
        return 1;
    }


    static double RuleEvaluation(double[] TotalSoal, double[] JawabanBenar, double[] WaktuTersisa, double w1, double w2, double w3)
    {
        //Aturan fuzzy Soal Hampir Tidak Terjawab
        double outputSkor1 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[0], WaktuTersisa[0]));
        double outputSkor2 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[0], WaktuTersisa[1]));
        double outputSkor3 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[0], WaktuTersisa[2]));
        double outputSkor4 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[1], WaktuTersisa[0]));
        double outputSkor5 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[1], WaktuTersisa[1]));
        double outputSkor6 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[1], WaktuTersisa[2]));
        double outputSkor7 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[2], WaktuTersisa[0]));
        double outputSkor8 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[2], WaktuTersisa[1]));
        double outputSkor9 = Math.Min(TotalSoal[0], Math.Min(JawabanBenar[2], WaktuTersisa[2]));

        //Aturan fuzzy Soal Beberapa Terjawab
        double outputSkor10 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[0], WaktuTersisa[0]));
        double outputSkor11 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[0], WaktuTersisa[1]));
        double outputSkor12 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[0], WaktuTersisa[2]));
        double outputSkor13 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[1], WaktuTersisa[0]));
        double outputSkor14 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[1], WaktuTersisa[1]));
        double outputSkor15 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[1], WaktuTersisa[2]));
        double outputSkor16 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[2], WaktuTersisa[0]));
        double outputSkor17 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[2], WaktuTersisa[1]));
        double outputSkor18 = Math.Min(TotalSoal[1], Math.Min(JawabanBenar[2], WaktuTersisa[2]));

        //Aturan fuzzy Soal Hampir Semua Terjawab
        double outputSkor19 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[0], WaktuTersisa[0]));
        double outputSkor20 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[0], WaktuTersisa[1]));
        double outputSkor21 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[0], WaktuTersisa[2]));
        double outputSkor22 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[1], WaktuTersisa[0]));
        double outputSkor23 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[1], WaktuTersisa[1]));
        double outputSkor24 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[1], WaktuTersisa[2]));
        double outputSkor25 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[2], WaktuTersisa[0]));
        double outputSkor26 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[2], WaktuTersisa[1]));
        double outputSkor27 = Math.Min(TotalSoal[2], Math.Min(JawabanBenar[2], WaktuTersisa[2]));

        double numerator = (w1 * outputSkor1) + (w1 * outputSkor2) + (w1 * outputSkor3) + (w1 * outputSkor4)
                            + (w1 * outputSkor5) + (w1 * outputSkor6) + (w1 * outputSkor7) + (w1 * outputSkor8)
                            + (w1 * outputSkor9) + (w1 * outputSkor10) + (w1 * outputSkor11) + (w1 * outputSkor12)
                            + (w2 * outputSkor13) + (w2 * outputSkor14) + (w2 * outputSkor15) + (w2 * outputSkor16)
                            + (w2 * outputSkor17) + (w2 * outputSkor18) + (w1 * outputSkor19) + (w1 * outputSkor20)
                            + (w1 * outputSkor21) + (w2 * outputSkor22) + (w2 * outputSkor23) + (w3 * outputSkor24)
                            + (w3 * outputSkor25) + (w3 * outputSkor26) + (w3 * outputSkor27);

        double denominator = outputSkor1 + outputSkor2 + outputSkor3 + outputSkor4 + outputSkor5 + outputSkor6
                            + outputSkor7 + outputSkor8 + outputSkor9 + outputSkor10 + outputSkor11 + outputSkor12
                            + outputSkor13 + outputSkor14 + outputSkor15 + outputSkor16 + outputSkor17 + outputSkor18
                            + outputSkor19 + outputSkor20 + outputSkor21 + outputSkor22 + outputSkor23 + outputSkor24
                            + outputSkor25 + outputSkor26 + outputSkor27;

        Debug.Log("Numerator = " + numerator);
        Debug.Log("Denominator = " + denominator);

        return numerator/denominator;
    }
}
