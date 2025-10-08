SELECT 
    s.ID AS StudentID,
    s.FirstName,
    s.LastName,
    e.EnrollmentID,
    e.CourseID,
    c.Title AS CourseTitle,
    e.Grade
FROM Students s
LEFT JOIN Enrollments e ON s.ID = e.StudentID
LEFT JOIN Courses c ON e.CourseID = c.CourseID
ORDER BY s.ID, e.CourseID