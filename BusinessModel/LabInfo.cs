using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class ResistanceToAntibiotics
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int parentId { get; set; }
        public string ParentTitle { get; set; }
    }

    public class LabInfo
    {
        //----اطلاعات کلی آزمایشگاه------
        public int AdmissionId { get; set; }
        public int SampleId { get; set; }
        public int SyndromicId { get; set; }
        public int diseasesId { get; set; }
        public long LabPrimaryId { get; set; }
        public long LabQuality { get; set; }
        // ------------ عفونت توام---------
        public int CoInfection { get; set; }
        //-------------ویروس-------------
        public int virusId { get; set; }
        public int subVirusId { get; set; }
        public int virusId2 { get; set; }
        public int subVirusId2 { get; set; }
        //-----------باکتری------------
        public int bacteriaId { get; set; }
        public int subBacteriaId { get; set; }
        public int bacteriaId2 { get; set; }
        public int subBacteriaId2 { get; set; }
        //------------سرمی--------------
        public int SerotypeVirusId { get; set; }
        public int AntiBodyInSerotypeId { get; set; }
        //---------مواد شمیایی---------
        public int SubstanceId { get; set; }
        //-----------XnoType------------
        public int vp_4Id { get; set; }
        public int vp_7Id { get; set; }
        //-----------Cholora------------
        public int bioTypeId { get; set; }
        public int seroTypeId { get; set; }
        public int chloraToxinId { get; set; }
        //-----------parazit------------
        public int parazitId { get; set; }

        // ----------- method -----------
        public long MethodId { get; set; }
        public long BordetellaId { get; set; }

        //-----------------------------------------
        public string ResistanceToAntibiotics { get; set; }
        public string LabResultDate { get; set; }
        public string LabSampleReciveDate { get; set; }
    }
}
