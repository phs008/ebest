BEGIN_FUNCTION_MAP
	.Func,ETF구성종목조회(t1904),t1904,attr,block,headtype=A;
	BEGIN_DATA_MAP
	t1904InBlock,기본입력,input;
	begin
		단축코드,shcode,shcode,char,6;
		종목CTS,cts_jcode,cts_jcode,char,12;
	end
	t1904OutBlock,출력,output;
	begin
		현재가,price,price,long,8;
		전일대비구분,sign,sign,char,1;
		전일대비,change,change,long,8;
		등락율,diff,diff,float,6.2;
		누적거래량,volume,volume,long,12;
		순자산총액,etftotcap,etftotcap,long,12;
		종목수,etfnum,etfnum,long,4;
		현금,cash,cash,long,12;
		종목CTS,cts_jcode,cts_jcode,char,12;
	end
	t1904OutBlock1,출력1,output,occurs;
	begin
		단축코드,shcode,shcode,char,12;
		한글명,hname,hname,char,20;
		현재가,price,price,long,8;
		전일대비구분,sign,sign,char,1;
		전일대비,change,change,long,8;
		등락율,diff,diff,float,6.2;
		누적거래량,volume,volume,long,12;
		단위증권수,icux,icux,long,6;
		이익분배기준일,profitdate,profitdate,char,8;
		액면금액,parprice,parprice,long,8.2;
	end
	END_DATA_MAP
END_FUNCTION_MAP

