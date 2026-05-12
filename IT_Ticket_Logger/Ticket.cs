using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Ticket_Logger
{
    // enum = = ชุกค่าที่กำหนดไว้ล่วงหน้า เพื่อป้องกันพิมพ์ผิด
    public enum TicketStatus
    {
        Open, //    เปิดตั๋วใหม่
        InProgress, // กำลังดำเนินการแก้ไขปัญหา
        Resolved, // แก้ไขปัญหาแล้ว แต่ยังไม่ปิดตั๋ว
        Closed // ปิดตั๋วแล้ว
    }

    // class = แม่แบบของ ticket 1 ใบ
    public class Ticket 
    {
        public int Id { get; set; } // รหัสตั๋ว
        public string Title { get; set; } // หัวข้อปัญหา
        public string Description { get; set; } // รายละเอียดปัญหา
        public TicketStatus Status { get; set; } // สถานะของตั๋ว
        public DateTime CreatedAt { get; set; } // วันที่สร้างตั๋ว

        public Ticket(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = TicketStatus.Open; // เริ่มต้นสถานะเป็น Open ใหม่เสมอ
            CreatedAt = DateTime.Now; // กำหนดวันที่สร้างเป็นเวลาปัจจุบัน
        }
    }
}
