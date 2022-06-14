using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Use.Models.DFS
{ 
    /// <summary>
    /// IN_DATA 배열 생성
    /// </summary>
    public class IN_DATA_Class
    {
        public List<IN_DATA2> IN_DATA { get; set; } = new List<IN_DATA2>();

        public IN_DATA_Class()
        {
            // IN_DATA 실제 내용입력
            IN_DATA2 in_data2 = new IN_DATA2();
            IN_DATA.Add(in_data2);
            IN_DATA.Add(in_data2);

        }
    }

    public class IN_DATA2
    {
        public string CATEGORY { get; set; }
        public DateTime VISION_INPUT_TIME { get; set; }
        public DateTime VISION_OUTPUT_TIME { get; set; }
        public float INSP_TACTIME { get; set; }
        public float INSP_PROCESSING_TIME { get; set; }
        public string RECIPE_ID { get; set; }
        public string NG_OUT { get; set; }
        public string EQP_ID { get; set; }
        public string EQP_INSP_ID { get; set; }
        public string PROCESS_GROUP { get; set; }
        public string PROCESS_NAME { get; set; }
        public int LINE_NUMBER { get; set; }
        public int MACHINE_NUMBER { get; set; }
        public int LANE_NUMBER { get; set; }
        public string VISION_TYPE { get; set; }
        public string PROCESS_DIRECTION { get; set; }
        public string LOT_ID { get; set; }
        public string CELL_ID { get; set; }
        public int CELL_COUNT_NO { get; set; }
        public string VIRTUAL_CELL_ID { get; set; }
        public string CELL_FINAL_JUDGE { get; set; }
        public List<IQ_INFO> IQ_INFOs { get; set; } = new List<IQ_INFO>();
        public string APPEARANCE_JUDGE_RESULT { get; set; }
        public int TOTAL_APPEARANCE_NG_COUNT { get; set; }
        public string[] APPEARANCE_REASON_ALL { get; set; }

        public IN_DATA2()
        {
            IQ_INFO in_data = new IQ_INFO();
            IQ_INFOs.Add(in_data);
        }
    }
    public class IQ_INFO
    {
        public string IQ_CAMERA_LOCATION { get; set; }
        public int IQ_CAMERA_NUMBER { get; set; }
        public int IQ_SCREEN_NUMBER { get; set; }
        public string IQ_CELL_POSITION { get; set; }
        public int IQ_SCREEN_IMAGE_SIZE_X { get; set; }
        public int IQ_SCREEN_IMAGE_SIZE_Y { get; set; }
        public float IQ_FOCUS_VALUE { get; set; }
        public float IQ_BRIGHT_VALUE { get; set; }
        public float IQ_RESOL_X_VALUE { get; set; }
        public float IQ_RESOL_Y_VALUE { get; set; }
        public float IQ_CAM_ANGLE_VALUE { get; set; }
        public float IQ_CAMERA_GAIN { get; set; }
        public float IQ_EXPOSURE_TIME { get; set; }
        public string IMAGE_JUDGE { get; set; }
        public string IMAGE_FILE_NAME { get; set; }
    }

    public class DEFECT_INFO
    {
        public int DEFECT_INDEX { get; set; }
        public string DEFECT_LD_CLASS { get; set; }
        public float DEFECT_DL_SCORE { get; set; }
        public string DEFECT_TYPE_DL_BASE_NAME { get; set; }
    }
}
