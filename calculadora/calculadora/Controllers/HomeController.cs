using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calculadora.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            Session["operador"] = "";
            Session["limpaVisor"] = true;
            Session["operadorAnterior"] = "";
            //preparar os primeiros valores da  calculadora
            ViewBag.visor = '0';
            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {

            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //recupera o resultado da decisao sobre a limpeza do visor
                    bool limpaEcran = (bool)Session["limpaVisor"];
                    //preocessa a escrita do pisor
                    if (limpaEcran || visor.Equals("0"))
                    {
                        visor = bt;
                    }
                    else visor += bt;
                    Session["limpaVisor"] = false;

                    break;
                case "-/+":
                    visor = Convert.ToDouble(visor) * -1 + "";
                    break;
                case ",":
                    if (!visor.Contains(","))
                    {
                        visor += ",";
                    }
                    break;
                case "+":
                case "-":
                case "x":
                case ":":
                case "=":
                    // se é a primeira vez que pressiono um operador
                    if (!((string)Session["operador"]).Equals(""))
                    {

                        //cria uma variavel de sessao e guarda o visor
                        //Session["primeiroOperando"]= visor;
                        //Session["operador"]= bt;
                        //prepara o visor para uma nova inst
                        //  Session["limpaVisor"] = true;

                        //agora é realizada a operação
                        double primOpre = Convert.ToDouble((string)Session["primeiroOperando"]);
                        //obter o 2 operando
                        double segOper = Convert.ToDouble(visor);

                        //escolher a operação a fazer 
                        switch ((string)Session["primeiroOperando"])
                        {


                            case "+":
                                visor = primOpre + segOper + "";

                                break;
                            case "-":
                                visor = primOpre - segOper + "";
                                break;
                            case "/":
                                visor = primOpre / segOper + "";
                                break;
                            case "*":
                                visor = primOpre * segOper + "";
                                break;
                        }// switch ((string)Session["operador"])

                        //preservar os valores para prox operacoes
                        // Session["operador"] = bt;
                        if (bt.Equals("="))
                        {
                            Session["operador"] = "";
                        }
                        else Session["operador"] = bt;

                        Session["primeiroOperando"] = visor;

                        // macar o visor para  limpeza
                        Session["limpaVisor"] = true;

                    }//if
                    break;

                case "C":
                    visor = "0";
                    Session["operador"] = "";
                    Session["limpaVisor"] = true;

                    //preparar os primeiros valores da  calculadora

                    break;

            }
            ViewBag.visor = visor;
            return View();
        }
    }
}