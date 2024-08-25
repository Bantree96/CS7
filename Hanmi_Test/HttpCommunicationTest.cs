using Hanmi.KEIDAS.INT.Client;
using System.Collections;
using System.Data;

namespace Hanmi_Test
{
	public class HttpCommunicationTest
    {
        /*STRING*/
        public void Run()
        {
            DataTable dtInputList = new DataTable();

            //===============================================================================================

            INTRequest intRequest = new INTRequest();
            string url = "http://220.85.176.48:7090/pmedi/ediHttpServer.do";

            //파라미터 설정
            Hashtable htParam = new Hashtable();
            htParam["P_LGIN_ID"] = "218166";                      //필수
            htParam["P_AUTH_TKEN"] = "1";                    //필수

            htParam["P_PRGM_ID"] = "131BEC53-C2A7-43E0-AACE-D32E89716FE8";                      // 필수
            htParam["P_LINE_CD"] = "JC_PDA_SHP";                      // 필수
            htParam["P_RDPT_CD"] = "JC_PDA_SHP3";                      // 필수

            //Param(String)
            htParam["LBOX_BACD_TAG_ID"] = "00788067180316873566";     // 대박스 바코드 ID
            htParam["ADDRS_BACD_TAG_ID"] = "41900570736";  // 주소 스티커 바코드 ID

            //Param(List)
            dtInputList.Columns.Add("LBOX_BACD_TAG_ID");       // 대박스 바코드 ID
            dtInputList.Columns.Add("ADDRS_BACD_TAG_ID");       // 주소 스티커 바코드 ID

            DataRow dr = dtInputList.NewRow();
            dr["LBOX_BACD_TAG_ID"] = "00788067180316873566";
            dr["ADDRS_BACD_TAG_ID"] = "41900570736";
            dtInputList.Rows.Add(dr);

            htParam["P_SHPB_TAG_LIST"] = dtInputList;

            //호출
            Hashtable htResult = intRequest.RequestINT("SP_SHPBE_RGST_VISION_LBOX", htParam, url, "218166", "zcbzcb@@22");

            //결과값 Return
            string sCODE = htResult["CODE"].ToString();
            string sMessage = htResult["MESSAGE"].ToString();
        }
    }
}

