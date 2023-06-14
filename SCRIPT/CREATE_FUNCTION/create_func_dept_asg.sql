
USE HRIS_PAY
GO
DROP FUNCTION func_dept_asg
GO
-- SELECT dbo.func_dept_asg('2089','department_name1')
CREATE FUNCTION func_dept_asg(    
    @p_empl_id			VARCHAR(10),
	@p_ret_type_str	    VARCHAR(100),
	@p_default_val	    VARCHAR(100)
	   
)    
 RETURNS VARCHAR(500)   
BEGIN    
   DECLARE @v_returnval			 VARCHAR(500) 
   DECLARE @count_asg        INT

   SET @count_asg = (SELECT COUNT(empl_id) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id) 
   IF @count_asg > 0
   BEGIN 
	   IF @p_ret_type_str = 'department_code'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(department_code,'') FROM payrollemployeemaster_asg_tbl 
								WHERE empl_id = @p_empl_id 
								AND effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'subdepartment_code'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(subdepartment_code,'') FROM payrollemployeemaster_asg_tbl 
								WHERE empl_id = @p_empl_id 
								AND effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'division_code'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(division_code,'') FROM payrollemployeemaster_asg_tbl 
								WHERE empl_id = @p_empl_id 
								AND effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'section_code'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(section_code,'') FROM payrollemployeemaster_asg_tbl 
								WHERE empl_id = @p_empl_id 
								AND effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'department_name1'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(department_name1,'') FROM payrollemployeemaster_asg_tbl A
		                        INNER JOIN HRIS_PAY.dbo.departments_tbl B
								ON B.department_code = A.department_code
								WHERE A.empl_id = @p_empl_id 
								AND A.effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'department_proper_name'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(department_proper_name,'') FROM payrollemployeemaster_asg_tbl A
								INNER JOIN HRIS_PAY.dbo.departments_tbl B
								ON B.department_code = A.department_code
								WHERE A.empl_id = @p_empl_id 
								AND A.effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
	   IF @p_ret_type_str = 'department_short_name'
	   BEGIN
           SET @v_returnval =  (SELECT ISNULL(department_short_name,'') FROM payrollemployeemaster_asg_tbl A
								INNER JOIN HRIS_PAY.dbo.departments_tbl B
								ON B.department_code = A.department_code
								WHERE A.empl_id = @p_empl_id 
								AND A.effective_date = (SELECT MAX(effective_date) FROM payrollemployeemaster_asg_tbl WHERE empl_id = @p_empl_id))
	   END
   END
   ELSE
   BEGIN 

       SET @v_returnval = (SELECT ISNULL(@p_default_val,''))
   END
    
   RETURN @v_returnval  
     
END    