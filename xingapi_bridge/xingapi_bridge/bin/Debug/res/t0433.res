BEGIN_FUNCTION_MAP
	.Func,선물/옵션미결제잔고(t0433),t0433,tuxcode=t0433,headtype=D;
	BEGIN_DATA_MAP
	t0433InBlock,기본입력,input;
	begin
		계좌번호,accno,accno,char,11;
		비밀번호,passwd,passwd,char,8;
		CTS_종목번호,cts_expcode,cts_expcode,char,8;
		CTS_매매구분,cts_medocd,cts_medocd,char,1;
	end
	t0433OutBlock,출력,output;
	begin
		매매손익합계,tdtsunik,tdtsunik,long,18;
		미결제약정합계,tmamt,tmamt,long,18;
		CTS_종목번호,cts_expcode,cts_expcode,char,8;
		CTS_매매구분,cts_medocd,cts_medocd,char,1;
	end
	t0433OutBlock1,출력1,output,occurs;
	begin
		종목번호,expcode,expcode,char,8;
		구분,medosu,medosu,char,4;
		잔고수량,jqty,jqty,long,10;
		평균단가,pamt,pamt,float,10.2;
		매매구분,medocd,medocd,char,1;
		총매입금액,mamt,mamt,long,18;
		처리순번,sysprocseq,sysprocseq,long,10;
	end
	END_DATA_MAP
END_FUNCTION_MAP

