using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Ticket_Logger
{
    public class TicketManager
    {
        // List = โครงสร้างข้อมูลที่เก็บข้อมูลหลายๆ ตัวในตัวแปรเดียว
        // private = เข้าถึงได้เฉพาะภายในคลาสนี้เท่านั้น
        private List<Ticket> tickets = new List<Ticket>(); // รายการเก็บตั๋วทั้งหมด
        private int nextId = 1; // ตัวนับรหัสตั๋วถัดไป

        // เพิ่มตั๋วใหม่ลงในระบบ
        public Ticket AddTicket(string title, string description)
        {
            var ticket = new Ticket(nextId, title, description); // สร้างตั๋วใหม่
            ticket.Id = nextId; // กำหนดรหัสตั๋ว
            nextId++;
            tickets.Add(ticket);
            return ticket;
        }

        // ดึง ตั๋วทั้งหมด
        public List<Ticket> GetAllTickets()
        {
            return tickets;
        }

        //หา ตั๋ว ตามรหัส
        //Ticket? = อาจจะได้ตั๋ว หรือ อาจจะไม่ได้ (null)
        public Ticket? GetById(int id)
        {
            return tickets.FirstOrDefault(t => t.Id == id); // ค้นหาตั๋วที่มีรหัสตรงกับ id ที่ส่งมา
        }

        // อัพเดตสถานะของตั๋ว - คืนค่า true ถ้าอัพเดตสำเร็จ, false ถ้าไม่พบตั๋ว
        public bool UpdateStatus(int id, TicketStatus newStatus)
        {
            var ticket = GetById(id);
            if (ticket == null) return false; // ไม่พบตั๋วที่มีรหัสนี้
            ticket.Status = newStatus;
            return true;
        }




    }
}
