//
//  <%%# e.ClassName.ToParscal() #%%>Service.m
//  MeetDragonAide
//
//  Created by Ellen on 15/9/22.
//  Copyright (c) 2015年 kuaifish.com. All rights reserved.
//

#import "<%%# e.ClassName.ToParscal() #%%>Service.h"
#import "<%%# e.ClassName.ToParscal() #%%>.h"
#import "DbManager.h"
#import "HTTPREQ.h"




@implementation <%%# e.ClassName.ToParscal() #%%>Service
singleton_implementation(<%%# e.ClassName.ToParscal() #%%>Service)


/**
 是否已创建
 */
-(BOOL)isCreated{
    NSString *key=@"IsTable<%%# e.ClassName.ToParscal() #%%>CreatedDb";
    NSUserDefaults *defaults=[[NSUserDefaults alloc]init];
    if ([[defaults valueForKey:key] intValue]!=1) {
        return NO;
    }else{
        return YES;
    }
}

/**
 设置创建标志
 */
-(void)setCreated{
    NSString *key=@"IsTabl<%%# e.ClassName.ToParscal() #%%>CreatedDb";
    NSUserDefaults *defaults=[[NSUserDefaults alloc]init];
    [defaults setValue:@1 forKey:key];
}

/**
 创建  <%%# e.ClassName.ToParscal() #%%>  表
 */
-(void)createTable{
    NSString *sql = [NSString stringWithFormat:@"CREATE TABLE <%%# e.ClassName #%%> (<%%# [Fields[Inner,0,0]={<%#= t.ColumnName #%> integer PRIMARY KEY AUTOINCREMENT, }] #%%><%%# [Fields[Inner,1,Last(1)]={<%#= t.ColumnName #%> text, }] #%%><%%# [Fields[Last,1]={<%#= t.ColumnName #%> text}] #%%>)"];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}

/**
 删除  <%%# e.ClassName.ToParscal() #%%>  表
 */
-(void)dropTable{
    
    NSString *sql = [NSString stringWithFormat:@"Drop TABLE <%%# e.ClassName #%%>"];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}

/**
 *  添加 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
-(void)add<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>{
    NSString *sql = [NSString stringWithFormat:@"INSERT INTO <%%# e.ClassName.ToParscal() #%%> (<%%# [Fields[Inner,1,Last(1)]={<%#= t.ColumnName #%>, }] #%%><%%# [Fields[Last,1]={<%#= t.ColumnName #%>}] #%%>) VALUES (<%%# [Fields[Inner,1,Last(1)]={'%@', }] #%%><%%# [Fields[Last,1]={'%@'}] #%%>)",<%%# [Fields[Inner,1,Last(1)]={<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%>, }] #%%><%%# [Fields[Last,1]={<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%>}] #%%> ];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}

/**
 *  删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
//-(void)remove<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>{
//    NSString *sql = [NSString stringWithFormat:@"DELETE FROM <%%# e.ClassName.ToParscal() #%%> WHERE <%%# e.getfirfieldName() #%%>='%@'",<%%# e.ClassName.ToCamel() #%%>.<%%# e.getfirfieldName() #%%>];
//    [[DbManager sharedDbManager] executeNonQuery:sql];
//}

/**
 *  根据 <%%# e.getfirfield().Comment #%%> 删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getfirfieldName() #%%> <%%# e.getfirfield().Comment #%%>
 */
-(void)remove<%%# e.ClassName.ToParscal() #%%>By<%%# e.getfirfieldName().ToParscal() #%%>:(NSString *)<%%# e.getfirfieldName() #%%>{
    NSString *sql = [NSString stringWithFormat:@"DELETE FROM <%%# e.ClassName.ToParscal() #%%> WHERE <%%# e.getfirfieldName() #%%>='%@'", <%%# e.getfirfieldName() #%%>];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}

/**
 *  根据 <%%# e.getsecfield().Comment #%%> 删除 <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getsecfieldName() #%%> <%%# e.getsecfield().Comment #%%>
 */
-(void)remove<%%# e.ClassName.ToParscal() #%%>By<%%# e.getsecfieldName().ToParscal() #%%>:(NSString *)<%%# e.getsecfieldName() #%%>{
    NSString *sql = [NSString stringWithFormat:@"DELETE FROM <%%# e.ClassName.ToParscal() #%%> WHERE <%%# e.getsecfieldName() #%%>='%@'", <%%# e.getsecfieldName() #%%>];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}


/**
 *  修改 <%%# e.ClassName.ToParscal() #%%>
 *
 *  @param <%%# e.ClassName.ToParscal() #%%> <%%# e.EntityName #%%>
 */
-(void)modify<%%# e.ClassName.ToParscal() #%%>:(<%%# e.ClassName.ToParscal() #%%> *)<%%# e.ClassName.ToCamel() #%%>{
    NSString *sql=[NSString stringWithFormat:@"UPDATE <%%# e.ClassName.ToParscal() #%%> SET <%%# [Fields[Inner,1,Last(1)]={<%#= t.ColumnName #%>='%@', }] #%%><%%# [Fields[Last,1]={<%#= t.ColumnName #%>='%@'}] #%%> WHERE <%%# e.getfirfieldName() #%%>='%@'",<%%# [Fields[Inner,1,Last(1)]={<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%>, }] #%%><%%# [Fields[Last,1]={<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%> }] #%%>, <%%# e.ClassName.ToCamel() #%%>.<%%# e.getfirfieldName() #%%>];
    [[DbManager sharedDbManager] executeNonQuery:sql];
    
    NSLog(@"Executed :%@", sql);
}


/**
 *  根据 <%%# e.getfirfield().Comment #%%> 取得  <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getfirfieldName().ToParscal() #%%> <%%# e.getfirfield().Comment #%%>
 *
 *  @return <%%# e.EntityName #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)get<%%# e.ClassName.ToParscal() #%%>By<%%# e.getfirfieldName().ToParscal() #%%>:(NSString *)<%%# e.getfirfieldName() #%%>{
    NSString *sql=[NSString stringWithFormat:@"SELECT * FROM <%%# e.ClassName.ToParscal() #%%> WHERE <%%# e.getfirfieldName() #%%>='%@'  order by <%%# e.getfirfieldName() #%%> desc ", <%%# e.getfirfieldName() #%%>];
    return [self executeEntitywithSql:sql];
}

/**
 *  根据 <%%# e.getsecfield().Comment #%%> 取得  <%%# e.EntityName #%%>
 *
 *  @param <%%# e.getsecfieldName().ToParscal() #%%> <%%# e.getsecfield().Comment #%%>
 *
 *  @return <%%# e.EntityName #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)get<%%# e.ClassName.ToParscal() #%%>By<%%# e.getsecfieldName().ToParscal() #%%>:(NSString *)<%%# e.getsecfieldName() #%%>{
    NSString *sql=[NSString stringWithFormat:@"SELECT * FROM <%%# e.ClassName.ToParscal() #%%> WHERE <%%# e.getsecfieldName() #%%>='%@'   order by <%%# e.getfirfieldName() #%%> desc ", <%%# e.getsecfieldName() #%%>];
    return [self executeEntitywithSql:sql];
}

-(NSArray *)getAll{
    NSString *sql=@"SELECT * FROM <%%# e.ClassName #%%>";
    return [self getEntitieswithSql:sql];
}

-(NSArray *)getAllWithPgIndex:(int)pgIndex pgSize:(int)pgSize{
    NSString *sql=[NSString stringWithFormat: @"SELECT * FROM <%%# e.ClassName #%%>  order by <%%# e.getfirfieldName() #%%> desc  limit %d,%d", (pgIndex - 1) * pgSize, pgSize];
    return [self getEntitieswithSql:sql];
}

-(int*)getCount{
    NSString *sql=[NSString stringWithFormat:@"SELECT count(<%%# e.getfirfieldName() #%%>) FROM <%%# e.ClassName #%%>"];
    return [self executeCountwithSql:sql];
}

-(int*)executeCountwithSql:(NSString*)sql{
    NSArray *rows= [[DbManager sharedDbManager] executeQuery:sql];
    if (rows&&rows.count>0) {
        NSString *result = [[rows objectAtIndex:0] objectForKey:[[rows objectAtIndex:0]allKeys][0]];
        return  [result intValue];
    }
    NSLog(@"Executed :%@", sql);
    return 0;
}

-(<%%# e.ClassName.ToParscal() #%%>*)executeEntitywithSql:(NSString*)sql{
    <%%# e.ClassName.ToParscal() #%%> *<%%# e.ClassName #%%>=[[<%%# e.ClassName.ToParscal() #%%> alloc]init];
    NSArray *rows= [[DbManager sharedDbManager] executeQuery:sql];
    if (rows&&rows.count>0) {
        [<%%# e.ClassName #%%> setValuesForKeysWithDictionary:rows[0]];
    }
    
    NSLog(@"Executed :%@", sql);
    return <%%# e.ClassName #%%>;
}

-(NSArray *)getEntitieswithSql:(NSString*)sql{
    NSMutableArray *array=[NSMutableArray array];
    NSArray *rows= [[DbManager sharedDbManager] executeQuery:sql];
    for (NSDictionary *dic in rows) {
        <%%# e.ClassName.ToParscal() #%%> *<%%# e.ClassName #%%>=[self get<%%# e.ClassName.ToParscal() #%%>By<%%# e.getfirfieldName().ToParscal() #%%>:dic[@"<%%# e.getfirfieldName() #%%>"]];
        [array addObject:<%%# e.ClassName #%%>];
    }
    return array;
}

-(void)Post_with:(<%%# e.ClassName.ToParscal() #%%>*)<%%# e.ClassName #%%> behavior:(NSString*)behavior block:(handleBlock)block{
    NSDictionary *dict = @{
                                @"behavior":behavior,
                           <%%# [Fields[Inner,1,Last(1)]={
                               <%#= e.ClassName.ToParscal() #%>_<%#= t.ColumnName #%>:<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%>, }] #%%><%%# [Fields[Last,1]={
                               <%#= e.ClassName.ToParscal() #%>_<%#= t.ColumnName #%>:<%#= e.ClassName.ToCamel() #%>.<%#= t.ColumnName #%>}] #%%>
                           };
    
    [[HTTPREQ sharedHTTPREQ]POSTwithurl:URLString dict:dict withBlock:block];
}


-(NSArray *)Post_getAllWithPgIndex:(int)pgIndex pgSize:(int)pgSize{
    NSDictionary *dict = @{
                           @"behavior":@"GetAll",
                           @"pgindex":[NSString stringWithFormat:@"%i", pgIndex],
                           @"pagesize":[NSString stringWithFormat:@"%i", pgSize],
                           };
    
    NSData *responsedata = [[HTTPREQ sharedHTTPREQ]POSTSyncwithurl:URLString dict:dict];
    
    
    NSDictionary *repdict = [NSJSONSerialization JSONObjectWithData:responsedata options:NSJSONReadingAllowFragments error:nil];
    
    NSArray *rows = repdict[@"data"];
    return [self transfromdataarray:rows];
}

-(int*)Post_getCount{
    NSDictionary *dict = @{
                           @"behavior":@"GetAllCount",
                           };
    
    NSData *responsedata = [[HTTPREQ sharedHTTPREQ]POSTSyncwithurl:URLString dict:dict];
    //    NSDictionary *dict = responsedat
    
    NSDictionary *repdict = [NSJSONSerialization JSONObjectWithData:responsedata options:NSJSONReadingAllowFragments error:nil];
    int count = [repdict[@"data"] integerValue];
    NSLog(@"count :%i", count);
    return count;
    
    //    return 100;
}

-(NSArray*)transfromdataarray:(NSArray *)rows{
    NSMutableArray *array = [[NSMutableArray alloc]init];
    
    for (NSDictionary *dic in rows) {
        <%%# e.ClassName.ToParscal() #%%> *<%%# e.ClassName #%%>=[[<%%# e.ClassName.ToParscal() #%%> alloc]init];
        
        if (rows&&rows.count>0) {
            
            [<%%# e.ClassName #%%> TransFromDictionary:dic];
        }
        [array addObject:<%%# e.ClassName #%%>];
    }
    return array;
}


@end
