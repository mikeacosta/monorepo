namespace WorkWell.API.Models;

public class JobsDataStore
{
    public List<JobDto> Jobs { get; set; }

    public JobsDataStore()
    {
        Jobs = new List<JobDto>()
        {
            new JobDto
            {
                Id = 1,
                Title = "Senior React Developer",
                Type = "Full-Time",
                Description = "We are seeking a talented Front-End Developer to join our team in Boston, MA. The ideal candidate will have strong skills in HTML, CSS, and JavaScript, with experience working with modern JavaScript frameworks such as React or Angular.",
                Location = "Boston, MA",
                Salary = "$70K - $80K",
                Company = new CompanyDto
                {
                    Name = "NewTek Solutions",
                    Description = "NewTek Solutions is a leading technology company specializing in web development and digital solutions. We pride ourselves on delivering high-quality products and services to our clients while fostering a collaborative and innovative work environment.",
                    ContactEmail = "contact@teksolutions.com",
                    ContactPhone = "555-555-5555"
                }
            },
            new JobDto
            {
                Id = 2,
                Title = "Front-End Engineer (React & Redux)",
                Type = "Full-Time",
                Description = "Join our team as a Front-End Developer in sunny Miami, FL. We are looking for a motivated individual with a passion for crafting beautiful and responsive web applications. Experience with UI/UX design principles and a strong attention to detail are highly desirable.",
                Location = "Miami, FL",
                Salary = "$70K - $80K",
                Company = new CompanyDto
                {
                    Name = "Veneer Solutions",
                    Description = "Veneer Solutions is a creative agency specializing in digital design and development. Our team is dedicated to pushing the boundaries of creativity and innovation to deliver exceptional results for our clients.",
                    ContactEmail = "contact@loremipsum.com",
                    ContactPhone = "555-555-5555"
                }
            },
            new JobDto
            {
                Id = 3,
                Title = "React.js Dev",
                Type = "Full-Time",
                Description = "Are you passionate about front-end development? Join our team in vibrant Brooklyn, NY, and work on exciting projects that make a difference. We offer competitive compensation and a collaborative work environment where your ideas are valued.",
                Location = "Brooklyn, NY",
                Salary = "$70K - $80K",
                Company = new CompanyDto
                {
                    Name = "Dolor Cloud",
                    Description = "Dolor Cloud is a leading technology company specializing in digital solutions for businesses of all sizes. With a focus on innovation and customer satisfaction, we are committed to delivering cutting-edge products and services.",
                    ContactEmail = "contact@dolorsitamet.com",
                    ContactPhone = "555-555-5555",
                }
            },
            new JobDto
            {
                Id = 4,
                Title = "React Front-End Developer",
                Type = "Part-Time",
                Description = "Join our team as a Part-Time Front-End Developer in beautiful Pheonix, AZ. We are looking for a self-motivated individual with a passion for creating engaging user experiences. This position offers flexible hours and the opportunity to work remotely.",
                Location = "Pheonix, AZ",
                Salary = "$60K - $70K",
                Company = new CompanyDto
                {
                    Name = "Alpha Elite",
                    Description = "Alpha Elite is a dynamic startup specializing in digital marketing and web development. We are committed to fostering a diverse and inclusive workplace where creativity and innovation thrive.",
                    ContactEmail = "contact@adipisicingelit.com",
                    ContactPhone = "555-555-5555",
                }
            },
            new JobDto
            {
                Id = 5,
                Title = "Full Stack React Developer",
                Type = "Full-Time",
                Description = "Exciting opportunity for a Full-Time Front-End Developer in bustling Atlanta, GA. We are seeking a talented individual with a passion for building elegant and scalable web applications. Join our team and make an impact!",
                Location = "Atlanta, GA",
                Salary = "$90K - $100K",
                Company = new CompanyDto
                {
                    Name = "Browning Technologies",
                    Description = "Browning Technologies is a rapidly growing technology company specializing in e-commerce solutions. We offer a dynamic and collaborative work environment where employees are encouraged to think creatively and innovate.",
                    ContactEmail = "contact@consecteturadipisicing.com",
                    ContactPhone = "555-555-5555",
                }
            },
            new JobDto
            {
                Id = 6,
                Title = "React Native Developer",
                Type = "Full-Time",
                Description = "Join our team as a Front-End Developer in beautiful Portland, OR. We are looking for a skilled and enthusiastic individual to help us create innovative web solutions. Competitive salary and great benefits package available.",
                Location = "Portland, OR",
                Salary = "$100K - $110K",
                Company = new CompanyDto
                {
                    Name = "Port Solutions INC",
                    Description = "Port Solutions is a leading technology company specializing in software development and digital marketing. We are committed to providing our clients with cutting-edge solutions and our employees with a supportive and rewarding work environment.",
                    ContactEmail = "contact@ipsumlorem.com",
                    ContactPhone = "555-555-5555",
                }
            }            
        };
    }
}